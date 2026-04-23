---
name: revit-addin-scaffold
description: Scaffold a Revit 2024 C# add-in project (.NET Framework 4.8) from a natural-language request. Produces a working .csproj, .addin manifest, IExternalCommand/IExternalApplication classes, and wires references to RevitAPI.dll. Use when the user asks to create, generate, or start a new Revit add-in, Revit plug-in, IExternalCommand, IExternalApplication, or Revit ribbon tool.
---

# Revit Add-in Scaffold

Generate a compile-ready Revit 2024 C# add-in from a plain-English description.

## When to use this skill

Trigger on requests like:
- "Create a Revit add-in that renames selected walls"
- "Build a Revit plug-in to export rooms to CSV"
- "Make an IExternalCommand that ..."
- "Start a new Revit ribbon tool ..."

If the user asks about Revit API semantics (what method to call, which class does X), delegate to the `revit-api-lookup` skill first, then return here for code generation.

## Workflow

Copy this checklist and track progress:

```
- [ ] Step 1: Find the closest existing plug-in in ../../../existingCodes/
- [ ] Step 2: Pick a project name, namespace, and command GUID
- [ ] Step 3: Decide Command vs Application (ribbon UI)
- [ ] Step 4: Copy templates from ./template/ and fill placeholders
- [ ] Step 5: Port/adapt logic from the closest sample; upgrade API refs to Revit 2024
- [ ] Step 6: Implement Execute() body (use revit-api-lookup if API unclear)
- [ ] Step 7: Hand off to revit-addin-build-deploy for build + install
```

### Step 1: Find the closest existing plug-in

The workspace has ~200 existing plug-ins under `existingCodes/`, indexed by domain in `existingCodes/INDEX.md`. **Always grep INDEX.md first** — each entry lists the plug-in's actions (in the authors' own words, often Chinese), target categories, parameters, APIs, and UI framework. This is 4-5× more token-efficient than reading source code to triangulate.

**Step 1a — grep INDEX.md**. Use keywords from the request (plus synonyms in both English and Chinese if relevant):

```powershell
# Run from the workspace root. English + Chinese keywords, 7 lines of context per hit:
rg -i "wall|墙|material|材质" existingCodes\INDEX.md -A 7

# Narrow to a domain section:
rg -i "## MEP|## Architecture" existingCodes\INDEX.md -A 0

# Filter by API pattern:
rg -i "Modeless.*ExternalEvent" existingCodes\INDEX.md -B 5
```

Look for entries whose **Actions** / **Dialogs** / **Categories** best match the request. Pick the top 1–2 candidates.

**Step 1b — Read the winner's source**. Only after INDEX.md narrows the field:

```powershell
# Read the matched project's Command.cs only:
Get-ChildItem <path-from-INDEX.md> -Recurse -Filter "Command*.cs" -File | Select-Object -First 2
```

Then Read 1–2 matching files to learn:
- Namespace pattern (commonly `<Tool>` or `<Company>.<Tool>`)
- Folder layout (flat vs `Commands/`, `Dialogs/`, `Utils/`, `<Domain>Info/`, `<Domain>Quant/`)
- Transaction-wrapping style
- UI framework (INDEX.md's `UI:` field already tells you WinForms vs WPF at a glance)
- Helper class patterns (often `Utils.cs`, `UIRibbon.cs`, `ErrorCollector.cs`)

**If `existingCodes/INDEX.md` is missing**, tell the user to run the one-time indexer (it takes ~3 seconds):

```powershell
powershell -ExecutionPolicy Bypass -File scripts/build-index.ps1
```

Then proceed. **If still no match**, fall back to name-based discovery (`Get-ChildItem existingCodes -Recurse -Filter *.csproj`), then to the template defaults in `./template/`.

### Important: Revit version migration

Existing plug-ins target **Revit 2020 or 2018** (see their csproj `<HintPath>`). Our templates target **Revit 2024**. When porting code:

- Replace API references to point at `C:\Program Files\Autodesk\Revit 2024\RevitAPI.dll` (the template csproj already does this via `$(RevitInstallPath)`).
- Watch for APIs deprecated in 2024:
  - `DisplayUnitType` → `ForgeTypeId` / `UnitTypeId` (since Revit 2021)
  - `UnitUtils.ConvertFromInternalUnits(value, DisplayUnitType.DUT_MILLIMETERS)` → `UnitUtils.ConvertFromInternalUnits(value, UnitTypeId.Millimeters)`
  - `ParameterType` → `SpecTypeId` / `GroupTypeId`
  - `ElementId.IntegerValue` still works in 2024 but is deprecated; use `ElementId.Value` when possible
- If a ported file won't compile, use the `revit-api-lookup` skill to find the 2024 equivalent.

### Step 2: Naming

Ask the user (or infer) for:
- **Project name**: PascalCase, no spaces — e.g. `WallRenamer`
- **Namespace**: follow `samples/` convention, fallback `RevitAddins.<ProjectName>`
- **Command name**: short, user-visible in Revit — e.g. `Rename Walls`
- **GUID**: generate a fresh one per command (`[guid]::NewGuid()` in PowerShell, or `Guid.NewGuid()`)

### Step 3: Command vs Application

| Choose | When |
|---|---|
| `IExternalCommand` only | Single button / keyboard shortcut, no persistent UI |
| `IExternalCommand` + `IExternalApplication` | Ribbon panel, multiple buttons, startup hooks |

For ribbon UIs, include both `Command.cs` and `Application.cs`.

### Step 4: Fill templates

The `./template/` folder contains placeholder files. Copy them into the new project directory and replace tokens:

| Token | Meaning |
|---|---|
| `{{NAMESPACE}}` | Root namespace, e.g. `RevitAddins.WallRenamer` |
| `{{ASSEMBLY_NAME}}` | DLL name without extension, e.g. `WallRenamer` |
| `{{CLASS_NAME}}` | Command class, e.g. `RenameWallsCommand` |
| `{{COMMAND_NAME}}` | Human label shown in Revit, e.g. `Rename Walls` |
| `{{TX_NAME}}` | Transaction label shown in undo, e.g. `Rename Walls` |
| `{{GUID}}` | Fresh GUID per `AddIn` element |
| `{{VENDOR_ID}}` | Short vendor code, e.g. `ACME` |
| `{{VENDOR_DESC}}` | Vendor description, e.g. `ACME Studio` |
| `{{ASSEMBLY_PATH}}` | Full path used by Revit to load the DLL (set during deploy step) |

Files to copy (rename to drop the `.template` suffix):

- `Project.csproj.template` → `<ProjectName>.csproj`
- `Project.addin.template` → `<ProjectName>.addin`
- `Command.cs.template` → `<ClassName>.cs`
- `Application.cs.template` → `App.cs` *(only if ribbon UI needed)*

### Step 5: Implement the command body

The template leaves a `// TODO: implement` marker inside the `Transaction` block. Fill it with the requested behavior. Key rules:

- Any change to the document **must** be inside a `Transaction` that is `Start()`ed and `Commit()`ed.
- Use `FilteredElementCollector` for element queries; avoid iterating the full `Document`.
- Prefer built-in parameters (`BuiltInParameter`) over string lookups for performance and localization.
- Never dispose `Document` or `UIDocument` — Revit owns them.
- Unhandled exceptions crash the command but not Revit — still, catch expected failures and set `message` before `return Result.Failed`.

If the request needs specific API calls you are unsure about, switch to the `revit-api-lookup` skill, find the right method signature, then return here.

### Step 6: Hand off

Once the code compiles conceptually, delegate to `revit-addin-build-deploy` to run MSBuild and copy the `.addin` + DLL into `%AppData%\Autodesk\Revit\Addins\2024\`.

## Templates

See [`template/`](./template/) for the four template files. Read them when scaffolding.

## Common patterns

See [`patterns.md`](./patterns.md) for condensed recipes (selection filters, transaction groups, failure handlers, ribbon panel creation).

## Anti-patterns to avoid

- Do **not** target .NET 6/8 — Revit 2024 is .NET Framework 4.8 only.
- Do **not** set `<Private>True</Private>` (i.e. Copy Local) on `RevitAPI.dll` / `RevitAPIUI.dll` — they must resolve from the Revit install at runtime.
- Do **not** use `TransactionMode.Automatic` — modern code uses `Manual`.
- Do **not** reuse a single `AddInId` GUID across multiple `<AddIn>` entries; each command needs its own.
- Do **not** use x86 / AnyCPU — Revit 2024 is x64 only.
