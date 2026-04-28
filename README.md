# Revit Add-in Skills for Cursor

Natural-language → compiled Revit 2024 C# add-in, end to end, inside Cursor.

Ask Cursor *"create a Revit add-in that renames all selected walls by appending their length in mm"*, and the agent scaffolds the project, looks up the API, writes the code, builds the DLL, and installs it into Revit's Addins folder. Every colleague on the team can do the same from their own machine.

## What's in here

Three composable Cursor skills under `.cursor/skills/`:

| Skill | Job |
|---|---|
| [`revit-addin-scaffold`](.cursor/skills/revit-addin-scaffold/SKILL.md) | Generate a new `.csproj` + `.addin` + `IExternalCommand` / `IExternalApplication` from a plain-English request. |
| [`revit-api-lookup`](.cursor/skills/revit-api-lookup/SKILL.md) | Look up API signatures, enums, and usage via the packaged structured symbol index (`symbols.jsonl` + clean markdown sidecars). No user-side CHM download required. |
| [`revit-addin-build-deploy`](.cursor/skills/revit-addin-build-deploy/SKILL.md) | MSBuild the project and copy the DLL + rewritten `.addin` into `%AppData%\Autodesk\Revit\Addins\2024\`. |

Plus two maintainer scripts in [`scripts/`](scripts) and a single-entry setup/check script at the repo root:

- [`setup.ps1`](setup.ps1) — onboarding check: verifies prerequisites and packaged indexes.
- [`scripts/build-index.ps1`](scripts/build-index.ps1) — maintainer tool that mines `existingCodes/` into the packaged scaffold `samples-index/`.
- [`scripts/build-api-index.ps1`](scripts/build-api-index.ps1) — maintainer tool that turns decompiled `RevitAPI.chm` into the packaged API symbol index + sidecars.

The agent picks the right skill from its description — you don't invoke them manually.

---

## Onboarding for a new colleague

Three steps. Normal users do not download Revit API docs or the original existing-code library.

### 1. Prerequisites

Install once on each developer machine:

| Tool | Why | Install link |
|---|---|---|
| Revit 2024 | Provides `RevitAPI.dll` / `RevitAPIUI.dll` for the build | (normal Revit install) |
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
2. Verify the packaged Revit API symbol index is present.
3. Verify the packaged scaffold sample index is present.

Safe to re-run. Maintainers can pass `-Force` (and optionally `-ChmPath`) to rebuild packaged indexes from their local `RevitAPI.chm` and `existingCodes/` source tree.

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

What travels: everything ordinary users need for lookup/scaffold/build. What's `.gitignore`d:

- `.cursor/skills/revit-api-lookup/docs/html/` — raw decompiled HTML, maintainer-only and regenerable from CHM
- `.cursor/skills/revit-api-lookup/*.chm` — Autodesk IP, never redistribute
- `existingCodes/INDEX.md` — legacy local output; the packaged catalog lives under `.cursor/skills/revit-addin-scaffold/samples-index/`
- `bin/`, `obj/`, any `*.user`, `*.suo`, `.vs/`

Committed with the skills:

- `.cursor/skills/revit-api-lookup/docs/symbols.jsonl`
- `.cursor/skills/revit-api-lookup/docs/md/**`
- `.cursor/skills/revit-addin-scaffold/samples-index/INDEX.md`
- `.cursor/skills/revit-addin-scaffold/samples-index/snippets/**`

### Option B — Zip file (simplest, no git required)

Zip the repo, keeping `.cursor/skills/**` so the packaged indexes travel with it:

```powershell
Compress-Archive -Path `
    .\.cursor, .\scripts, .\setup.ps1, .\README.md, .\.gitignore `
    -DestinationPath .\RevitSkills.zip
```

Email / share the zip. Colleagues unzip and run `.\setup.ps1` to verify prerequisites. Downside: no painless update path — you redistribute a new zip each time.

### Option C — Shared network drive

Point the team at `\\fileserver\tools\RevitSkills\`. Each user `robocopy`s it locally first, then runs `setup.ps1`. Works but less clean than git; no history.

### What you should **not** redistribute in any scenario

- `RevitAPI.chm` itself — Autodesk IP. Only maintainers need it when refreshing the packaged API index.
- Raw `docs/html/` output from CHM decompilation.
- Full `existingCodes/` trees that include third-party or private source you do not want to redistribute. The packaged `samples-index/` is the normal-user reference surface.

---

## Example prompts once set up

- *"Create a Revit add-in that renames all selected walls by appending their length in millimeters."*
- *"Build a ribbon with three buttons: export rooms to CSV, tag all doors, place a dimension between two picked walls."*
- *"What's the Revit API method for getting a wall's base offset?"* *(triggers the lookup skill alone)*
- *"Deploy the `WallRenamer` add-in to Revit."* *(triggers the build/deploy skill alone)*

The packaged sample index was generated from existing projects that may target Revit 2020/2018; the scaffold skill upgrades API references to Revit 2024 when porting patterns (see [scaffold SKILL.md](.cursor/skills/revit-addin-scaffold/SKILL.md) → *Revit version migration*).

## Layout

```
d:\Codes\RevitSkills\
├── .cursor/skills/
│   ├── revit-addin-scaffold/      SKILL.md + template/ + patterns.md + samples-index/
│   ├── revit-api-lookup/          SKILL.md + scripts/ + cheatsheet.md + docs/ (packaged index)
│   └── revit-addin-build-deploy/  SKILL.md + scripts/deploy-addin.ps1
├── scripts/
│   ├── build-index.ps1            mines existingCodes/ -> scaffold samples-index
│   └── build-api-index.ps1        preprocesses RevitAPI docs -> symbols.jsonl + md sidecars
├── existingCodes/                 optional maintainer-only source material
├── setup.ps1                      one-shot onboarding for new machines
├── .gitignore
└── README.md                      this file
```
