# Revit Add-in Skills for Cursor

Natural-language → compiled Revit 2024 C# add-in, end to end, inside Cursor.

Ask Cursor *"create a Revit add-in that renames all selected walls by appending their length in mm"*, and the agent scaffolds the project, looks up the API, writes the code, builds the DLL, and installs it into Revit's Addins folder. Every colleague on the team can do the same from their own machine.

## What's in here

Three composable Cursor skills under `.cursor/skills/`:

| Skill | Job |
|---|---|
| [`revit-addin-scaffold`](.cursor/skills/revit-addin-scaffold/SKILL.md) | Generate a new `.csproj` + `.addin` + `IExternalCommand` / `IExternalApplication` from a plain-English request. |
| [`revit-api-lookup`](.cursor/skills/revit-api-lookup/SKILL.md) | Look up API signatures, enums, and usage via a structured symbol index (12 MB JSONL + 36K clean markdown sidecars) built once from `RevitAPI.chm`. Fulltext fallback for prose queries. |
| [`revit-addin-build-deploy`](.cursor/skills/revit-addin-build-deploy/SKILL.md) | MSBuild the project and copy the DLL + rewritten `.addin` into `%AppData%\Autodesk\Revit\Addins\2024\`. |

Plus two project-level setup scripts in [`scripts/`](scripts) and a single-entry orchestrator at the repo root:

- [`setup.ps1`](setup.ps1) — one-shot onboarding: prereq check + run all setup scripts below.
- [`scripts/build-index.ps1`](scripts/build-index.ps1) — mines `existingCodes/` into `INDEX.md`, the catalog the scaffold skill greps before generating code.
- [`scripts/build-api-index.ps1`](scripts/build-api-index.ps1) — turns the decompiled `RevitAPI.chm` into a structured JSONL symbol index + per-symbol markdown sidecars for the lookup skill.

The agent picks the right skill from its description — you don't invoke them manually.

---

## Onboarding for a new colleague

Three steps. Takes ~10 minutes the first time, most of which is idle CHM decompilation.

### 1. Prerequisites

Install once on each developer machine:

| Tool | Why | Install link |
|---|---|---|
| Revit 2024 | Provides `RevitAPI.dll` / `RevitAPIUI.dll` for the build | (normal Revit install) |
| Revit 2024 SDK | Ships `RevitAPI.chm` — the API docs source of truth | [Autodesk developer portal](https://www.autodesk.com/developer-network/platform-technologies/revit) |
| .NET SDK 6.0+ **or** VS Build Tools | Compiles the add-ins (the repo's `deploy-addin.ps1` picks whichever is on PATH) | [dotnet.microsoft.com/download](https://dotnet.microsoft.com/download) |
| Cursor (or VS Code) | Runs the skills; also ships the `ripgrep` binary the skills use | [cursor.com](https://cursor.com/) |
| Git | Clones and pulls updates | [git-scm.com](https://git-scm.com/) |

### 2. Clone and run setup

```powershell
git clone <your-internal-repo-url> RevitSkills
cd RevitSkills
.\setup.ps1
```

`setup.ps1` will:

1. Check Revit 2024, a builder (msbuild or dotnet), and ripgrep.
2. Find `RevitAPI.chm` in the Revit SDK (or accept a `-ChmPath` override).
3. Decompile the CHM into HTML (~3 min).
4. Build the symbol index + markdown sidecars (~3 min).
5. Build `existingCodes/INDEX.md` (~3 sec).

Safe to re-run — each step skips if its output already exists. Pass `-Force` to rebuild everything.

If Revit is installed somewhere other than `C:\Program Files\Autodesk\Revit 2024\`, set this once in your PowerShell profile before building any add-in:

```powershell
$env:RevitInstallPath = 'D:\YourPath\Autodesk\Revit 2024'
```

The csproj template reads that env var; no file edits needed.

### 3. Use it

Open the folder in Cursor and ask in natural language:

> *"Create a Revit add-in that exports all rooms in the active view to CSV with number, name, and area in m²."*

The agent will scaffold a project, look up APIs, generate code, build, and deploy it to **your own** `%AppData%\Autodesk\Revit\Addins\2024\`. Launch Revit 2024 and the add-in appears under `Add-Ins → External Tools`.

---

## How the add-in gets loaded in Revit

The build-deploy skill uses Revit's own add-in discovery protocol. On each developer's machine:

1. `deploy-addin.ps1` compiles the project and writes the output DLL + rewritten `.addin` manifest into `%AppData%\Autodesk\Revit\Addins\2024\` — Revit scans this folder at startup.
2. Inside the manifest, the `<Assembly>` element is rewritten from the relative path in the source file to the absolute path of **that user's** deployed DLL — so no two colleagues clash, and no path needs hand-editing.
3. Revit 2024 loads the DLL via reflection on next launch and shows the command under `Add-Ins → External Tools` (or wherever the `IExternalApplication` places its ribbon buttons).

**If you want one add-in to load for every user on a shared workstation**, point `-AddinsDir` at `C:\ProgramData\Autodesk\Revit\Addins\2024\` when running deploy-addin. That path is machine-wide and requires admin write.

**If you want to share a pre-built add-in with a colleague without rebuilding**, just send them `<YourAddin>.dll` + `<YourAddin>.addin` and have them drop both into their own `%AppData%\Autodesk\Revit\Addins\2024\`. The deploy script isn't required for consumers — only for developers who are compiling.

---

## Distribution: how to pass the skills to the team

Pick whichever model fits your team:

### Option A — Internal git repo (recommended)

Put this folder on your org's GitLab / GitHub Enterprise / Azure DevOps. Colleagues:

```powershell
git clone <url>
cd RevitSkills
.\setup.ps1
```

Pros: versioned, reviewable, `git pull` brings new skill updates. You can branch/PR changes to skill prompts the same way as code.

What travels: everything under source control. What's `.gitignore`d and regenerated locally:

- `.cursor/skills/revit-api-lookup/docs/` (decompiled HTML + 36K md sidecars + `symbols.jsonl`) — ~450 MB, all regenerable from the CHM
- `.cursor/skills/revit-api-lookup/*.chm` — each colleague gets their own from their local SDK install
- `existingCodes/INDEX.md` — regenerated from the `existingCodes/` folder on each machine
- `bin/`, `obj/`, any `*.user`, `*.suo`, `.vs/`

### Option B — Zip file (simplest, no git required)

Zip the repo, skipping the big generated folders:

```powershell
Compress-Archive -Path `
    .\.cursor, .\scripts, .\existingCodes, .\setup.ps1, .\README.md, .\.gitignore `
    -DestinationPath .\RevitSkills.zip
```

Email / share the zip. Colleagues unzip and run `.\setup.ps1`. Downside: no painless update path — you redistribute a new zip each time.

### Option C — Shared network drive

Point the team at `\\fileserver\tools\RevitSkills\`. Each user `robocopy`s it locally first (the skill scripts write to `docs/`, which needs to be machine-local), then runs `setup.ps1`. Works but less clean than git; no history.

### What you should **not** redistribute in any scenario

- `RevitAPI.chm` itself — Autodesk IP. Each colleague already has it via their own Revit SDK install, and `setup.ps1` finds it.
- Anything under `existingCodes/` that's 3rd-party code you don't own the license to — audit that folder before opening the repo outside your team.

---

## Example prompts once set up

- *"Create a Revit add-in that renames all selected walls by appending their length in millimeters."*
- *"Build a ribbon with three buttons: export rooms to CSV, tag all doors, place a dimension between two picked walls."*
- *"What's the Revit API method for getting a wall's base offset?"* *(triggers the lookup skill alone)*
- *"Deploy the `WallRenamer` add-in to Revit."* *(triggers the build/deploy skill alone)*

Existing projects under `existingCodes/` target Revit 2020/2018; the scaffold skill upgrades API references to Revit 2024 when porting code (see [scaffold SKILL.md](.cursor/skills/revit-addin-scaffold/SKILL.md) → *Revit version migration*).

## Layout

```
d:\Codes\RevitSkills\
├── .cursor/skills/
│   ├── revit-addin-scaffold/      SKILL.md + template/ + patterns.md
│   ├── revit-api-lookup/          SKILL.md + scripts/ + cheatsheet.md + docs/ (generated, gitignored)
│   └── revit-addin-build-deploy/  SKILL.md + scripts/deploy-addin.ps1
├── scripts/
│   ├── build-index.ps1            mines existingCodes/ -> INDEX.md
│   └── build-api-index.ps1        preprocesses RevitAPI docs -> symbols.jsonl + md sidecars
├── existingCodes/                 your ~200 existing plug-ins (reference material)
│   └── INDEX.md                   generated catalog, agent greps this first (gitignored)
├── setup.ps1                      one-shot onboarding for new machines
├── .gitignore
└── README.md                      this file
```
