---
name: revit-addin-scaffold
description: Scaffold a Revit 2024 C# add-in project (.NET Framework 4.8) from a natural-language request. Produces a working .csproj, .addin manifest, IExternalCommand/IExternalApplication classes, and wires references to RevitAPI.dll. Use when the user asks to create, generate, or start a new Revit add-in, Revit plug-in, IExternalCommand, IExternalApplication, or Revit ribbon tool.
---

# Revit Add-in Scaffold

Generate a compile-ready Revit 2024 C# add-in from a plain-English description.

## When to use this skill

Trigger on requests like:
- "Create a Revit add-in that renames selected walls"
- "创建一个重命名选定墙体的 Revit 插件" / "生成一个导出房间到 CSV 的插件"
- "Build a Revit plug-in to export rooms to CSV"
- "Make an IExternalCommand that ..."
- "Start a new Revit ribbon tool ..."

If the user asks about Revit API semantics (what method to call, which class does X), delegate to the `revit-api-lookup` skill first, then return here for code generation.

## Bilingual prompt protocol (read first)

Prompts and packaged sample indexes mix Chinese and English; the Revit API is English-only. Keep retrieval symmetric by following these steps **before any search**:

1. **Consult the glossary once per session**: `.cursor/skills/glossary.zh-en.md`. It maps ~150 Revit domain terms across `en ↔ zh ↔ api`.
2. **For every keyword you would grep, also grep the other language.** Combine into a single regex with `|`:
   ```powershell
   rg -i "pipe|管道|pipeline|管线"  .cursor\skills\revit-addin-scaffold\samples-index\INDEX.md -A 8
   rg -i "hanger|吊架"              .cursor\skills\revit-addin-scaffold\samples-index\INDEX.md -A 8
   rg -i "wall.*area|墙.*面积"       .cursor\skills\revit-addin-scaffold\samples-index\INDEX.md -A 8
   ```
   The regenerated `INDEX.md` now contains a `Tags:` line per entry unioning EN+ZH synonyms from the glossary, so either-language grep hits the same records.
3. **When writing strings the user will see** (dialog titles, ribbon button text, transaction labels): match the language of the user's prompt. A user who prompted in Chinese expects Chinese UI; a user who prompted in English expects English UI.
4. **If a term is missing from the glossary**, add a row to it *before* continuing. The glossary is the system's memory — every new term improves retrieval for the next request.

## Workflow

Copy this checklist and track progress:

```
- [ ] Step 1: Find the closest packaged reference in ./samples-index/
- [ ] Step 2: Pick a project name, namespace, and command GUID
- [ ] Step 3: Decide Command vs Application (ribbon UI)
- [ ] Step 4: Copy templates from ./template/ and fill placeholders
- [ ] Step 5: Port/adapt logic from the closest sample; upgrade API refs to Revit 2024
- [ ] Step 6: Implement Execute() body (use revit-api-lookup if API unclear)
- [ ] Step 7: Create README.zh-CN.md with functionality, usage, and implementation notes
- [ ] Step 8: Hand off to revit-addin-build-deploy for build + install
```

### Step 1: Find the closest packaged reference

The skill ships with a packaged reference catalog at `.cursor/skills/revit-addin-scaffold/samples-index/INDEX.md`, generated from the maintainer's existing plug-ins. Normal users do **not** need the full `existingCodes/` tree. **Always grep this packaged INDEX.md first** — each entry lists the plug-in's actions (in the authors' own words, often Chinese), target categories, parameters, APIs, UI framework, tags, and a compact snippet path when available.

**Step 1a — grep packaged INDEX.md**. Union English + Chinese synonyms in the regex (see Bilingual prompt protocol above). The `Tags:` line on each entry carries the glossary's EN+ZH union, so either language hits the same records:

```powershell
# Run from the workspace root. Bilingual regex, 8 lines of context per hit:
rg -i "wall|墙.*material|材质"   .cursor\skills\revit-addin-scaffold\samples-index\INDEX.md -A 8
rg -i "pipe|管道.*elevation|高程" .cursor\skills\revit-addin-scaffold\samples-index\INDEX.md -A 8
rg -i "hanger|吊架"              .cursor\skills\revit-addin-scaffold\samples-index\INDEX.md -A 8

# Narrow to a domain section:
rg -i "## MEP|## Architecture" .cursor\skills\revit-addin-scaffold\samples-index\INDEX.md -A 0

# Filter by API pattern:
rg -i "Modeless.*ExternalEvent" .cursor\skills\revit-addin-scaffold\samples-index\INDEX.md -B 5
```

Look for entries whose **Actions** / **Dialogs** / **Categories** / **Tags** best match the request. Pick the top 1–2 candidates.

**Step 1b — Read the packaged snippet**. Only after INDEX.md narrows the field, read the matched entry's `Snippet:` file under `samples-index/snippets/`. Use it to learn the command structure, transaction pattern, helper style, UI framework, and key API calls without needing the complete source tree.

If a maintainer workspace also has full `existingCodes/`, you may optionally read the matched `Path:` for deeper migration work. Do this only when the packaged snippet is insufficient or the user explicitly asks to port a full legacy add-in.

```powershell
# Read the matched compact reference:
Get-Content .cursor\skills\revit-addin-scaffold\samples-index\snippets\<matched-snippet>.md -Raw
```

Then use the snippet and index entry to learn:
- Namespace pattern (commonly `<Tool>` or `<Company>.<Tool>`)
- Folder layout (flat vs `Commands/`, `Dialogs/`, `Utils/`, `<Domain>Info/`, `<Domain>Quant/`)
- Transaction-wrapping style
- UI framework (INDEX.md's `UI:` field already tells you WinForms vs WPF at a glance)
- Helper class patterns (often `Utils.cs`, `UIRibbon.cs`, `ErrorCollector.cs`)

**If packaged `samples-index/INDEX.md` is missing**, do not ask ordinary users to download `existingCodes/`. Tell maintainers to regenerate the packaged index from their private/reference source tree:

```powershell
powershell -ExecutionPolicy Bypass -File scripts/build-index.ps1
```

Then proceed. **If still no match**, use `patterns.md`, `revit-api-lookup`, and the templates in `./template/`. Only fall back to full `existingCodes/` discovery in a maintainer workspace where that directory actually exists.

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
- `README.zh-CN.md.template` → `README.zh-CN.md`

The README template contains additional content placeholders such as `{{FUNCTION_SUMMARY}}`, `{{IMPLEMENTATION_POINT_1}}`, and `{{REVIT_API_1}}`. Treat these as writing prompts, not mechanical tokens: replace them with concrete Chinese prose based on the actual generated code.

### Step 5-6: Port/adapt and implement the command body

The template leaves a `// TODO: implement` marker inside the `Transaction` block. Fill it with the requested behavior. Key rules:

- Any change to the document **must** be inside a `Transaction` that is `Start()`ed and `Commit()`ed.
- Use `FilteredElementCollector` for element queries; avoid iterating the full `Document`.
- Prefer built-in parameters (`BuiltInParameter`) over string lookups for performance and localization.
- Never dispose `Document` or `UIDocument` — Revit owns them.
- Unhandled exceptions crash the command but not Revit — still, catch expected failures and set `message` before `return Result.Failed`.

If the request needs specific API calls you are unsure about, switch to the `revit-api-lookup` skill, find the right method signature, then return here.

### Step 7: Create Chinese technical documentation

After the add-in code is generated, create `<ProjectName>/README.zh-CN.md`. This is required for every scaffolded plug-in, even small one-command tools. Use `template/README.zh-CN.md.template` as the starting structure, but replace every placeholder with concrete details from the generated project.

The document must be written in Chinese and include:

- **插件功能**: what the tool does, what elements/categories it affects, and the expected result.
- **使用说明**: how to build/deploy if already installed by the build skill, where the command appears in Revit, selection/preconditions, and step-by-step operation.
- **代码实现方式**: project files, command/application classes, important helper methods, transaction boundaries, collectors/filters, parameters, and key Revit API types.
- **适用环境**: Revit 2024, .NET Framework 4.8, x64, and any project-specific assumptions.
- **注意事项**: limitations, failure cases, units, language/localization choices, and safe rollback behavior.

Keep it practical: future users should understand how to run the add-in without reading code, and future developers should understand where to change the implementation.

### Step 8: Hand off

Once the code compiles conceptually, delegate to `revit-addin-build-deploy` to run MSBuild and copy the `.addin` + DLL into `%AppData%\Autodesk\Revit\Addins\2024\`.

## Templates

See [`template/`](./template/) for the project, manifest, command, application, and Chinese README templates. Read them when scaffolding.

## Common patterns

See [`patterns.md`](./patterns.md) for condensed recipes (selection filters, transaction groups, failure handlers, ribbon panel creation).

## Anti-patterns to avoid

- Do **not** target .NET 6/8 — Revit 2024 is .NET Framework 4.8 only.
- Do **not** set `<Private>True</Private>` (i.e. Copy Local) on `RevitAPI.dll` / `RevitAPIUI.dll` — they must resolve from the Revit install at runtime.
- Do **not** use `TransactionMode.Automatic` — modern code uses `Manual`.
- Do **not** reuse a single `AddInId` GUID across multiple `<AddIn>` entries; each command needs its own.
- Do **not** use x86 / AnyCPU — Revit 2024 is x64 only.
