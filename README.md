# Revit Add-in Skills for Cursor / Cline

Use **Cursor / Cline** with plain English to scaffold Revit 2024 C# add-ins, look up the API, build, and deploy the compiled DLL plus `.addin` manifest to the folder you choose on first use.

This repo ships agent skills under [`.cursor/skills/`](.cursor/skills/) so everyone on your team gets the same prompts, lookup index, and deploy script—clone (or unzip), open the folder in Cursor/Cline, and start asking.

## What you get

| Skill | Role |
| --- | --- |
| [`revit-addin-scaffold`](.cursor/skills/revit-addin-scaffold/SKILL.md) | New `.csproj`, `.addin`, and `IExternalCommand` / `IExternalApplication` from a natural-language request. |
| [`revit-api-lookup`](.cursor/skills/revit-api-lookup/SKILL.md) | API signatures and usage via the packaged index ([`symbols.jsonl`](.cursor/skills/revit-api-lookup/docs/symbols.jsonl) and markdown sidecars). No CHM download required for normal use. |
| [`revit-addin-build-deploy`](.cursor/skills/revit-addin-build-deploy/SKILL.md) | MSBuild and copy the DLL plus a rewritten `.addin` into your saved deploy folder. The deploy script lives **inside** this skill: [`deploy-addin.ps1`](.cursor/skills/revit-addin-build-deploy/scripts/deploy-addin.ps1). |

The agent chooses skills from their descriptions—you normally do not run them by name.

---

## Prerequisites (each machine)

| Need | Why |
| --- | --- |
| **Revit 2024** | Supplies `RevitAPI.dll` / `RevitAPIUI.dll` for builds. |
| **.NET SDK 6+** or **Visual Studio Build Tools** | MSBuild / `dotnet` to compile add-ins (the bundled deploy script uses what is on your `PATH`). |
| **Cursor** (or compatible editor with Agent + skills) | Runs the skills; `ripgrep` is useful for indexed search in the API skill. |
| **Git** (if you use `git clone`) | Clone and `git pull` for updates. |

If Revit is not under `C:\Program Files\Autodesk\Revit 2024\`, set this before building:

```powershell
$env:RevitInstallPath = 'D:\YourPath\Autodesk\Revit 2024'
```

The project template respects this variable; no hand-editing paths in the `.csproj` for a standard install layout.

---

## First-time configuration

After downloading this repo, each new user should configure two paths before expecting build/deploy to work reliably.

### 1. Configure the Revit install path

The templates assume Revit 2024 is installed here:

```powershell
C:\Program Files\Autodesk\Revit 2024
```

If your Revit 2024 install is somewhere else, set `RevitInstallPath` before scaffolding or building:

```powershell
$env:RevitInstallPath = 'D:\YourPath\Autodesk\Revit 2024'
```

To save it permanently for your Windows user:

```powershell
[Environment]::SetEnvironmentVariable('RevitInstallPath', 'D:\YourPath\Autodesk\Revit 2024', 'User')
```

Restart Cursor/Cline after setting the permanent variable so new terminals inherit it.

### 2. Configure where compiled DLLs go

The first time you ask the agent to build/deploy an add-in, it should ask:

> Where should compiled Revit add-ins be deployed?

If you want Revit to load the add-in automatically on next launch, use the per-user Revit Addins folder:

```powershell
$env:AppData\Autodesk\Revit\Addins\2024
```

You can also choose another folder, for example `D:\RevitAddins\2024`, if your team copies add-ins from there.

The deploy script saves the chosen folder here:

```powershell
$env:AppData\RevitSkills\revit-addin-build-deploy.json
```

After that, all future builds deploy to the saved folder automatically.

To change the deploy folder later, run one build with `-AddinsDir`:

```powershell
powershell -ExecutionPolicy Bypass -File .cursor/skills/revit-addin-build-deploy/scripts/deploy-addin.ps1 -ProjectPath "path\to\YourAddin.csproj" -AddinsDir "D:\RevitAddins\2024"
```

Or delete/edit:

```powershell
$env:AppData\RevitSkills\revit-addin-build-deploy.json
```

### 3. Verify build tools

Install one of these before building:

- Visual Studio / Visual Studio Build Tools with MSBuild
- .NET SDK 6+ plus the .NET Framework 4.8 targeting pack

Close Revit before deployment. Revit locks loaded DLLs, so copying a new build while Revit is open can fail.

---

## Quick start

1. **Get the repo** — `git clone <your-repo-url>` or unzip a copy your team distributes.
2. **Open the repo root in Cursor/Cline** so `.cursor/skills/` is available to the agent.
3. **Ask for an add-in in chat**, for example: *"Create a Revit add-in that exports all rooms in the active view to CSV with number, name, and area in m²."*

The agent should scaffold, look up APIs, implement, run build/deploy, and place the add-in under your saved deploy folder. Restart Revit 2024 and look under **Add-Ins → External Tools** (or your ribbon if the add-in registers one).

---

## How Revit loads the add-in

1. The build-deploy flow compiles the project and writes the DLL and a **rewritten** `.addin` under your saved deploy folder. Revit reads `%AppData%\Autodesk\Revit\Addins\2024\` at startup by default.
2. The manifest’s `<Assembly>` path is set to **your** deployed DLL so paths are not shared blindly between machines.
3. For **all users on one PC**, you can target `C:\ProgramData\Autodesk\Revit\Addins\2024\` if your team’s process allows (often needs admin). Pass it once with `-AddinsDir` to save it as your deploy folder.

To **share a built add-in** without rebuilding: give someone the `.dll` + `.addin` and they copy both into their own user Addins folder—no need to run the deploy script on their side.

---

## Sharing the skills with your team

**Git (recommended)** — Push this repo to GitHub / GitLab / Azure DevOps. Teammates clone and open in Cursor/Cline; `git pull` brings skill updates.

**Zip** — Pack at least:

- `.cursor/` (entire tree, so skills and packaged indexes stay together)
- `README.md` and `.gitignore` if you use them

There is **no** root `setup.ps1` in this distribution; onboarding is: install prerequisites, open the folder in Cursor/Cline, configure the two paths above, and go.

---

## Example prompts

- *"Create a Revit add-in that renames all selected walls by appending their length in millimeters."*
- *"Add a ribbon with three buttons: export rooms to CSV, tag all doors, dimension between two picked walls."*
- *"What Revit API gets a wall's base offset?"* (mostly API lookup)
- *"Build and deploy the `WallRenamer` add-in to Revit."* (mostly build-deploy)

Sample patterns in the scaffold skill may mention older Revit versions; the scaffold skill is written to port patterns to Revit 2024—see [revit-addin-scaffold SKILL.md](.cursor/skills/revit-addin-scaffold/SKILL.md).

---

## Repo layout (what you have after clone)

```
RevitSkills/
├── .cursor/
│   └── skills/
│       ├── revit-addin-scaffold/       SKILL.md, docs/, templates/, scripts/
│       ├── revit-api-lookup/           SKILL.md, scripts/, docs/ (packaged index + md)
│       └── revit-addin-build-deploy/   SKILL.md, scripts/deploy-addin.ps1
├── .gitignore
└── README.md
```

Maintainer-only tooling (regenerating the API index from CHM, mining legacy code into `revit-addin-scaffold/docs/samples-index/`, etc.) is **not** part of this repo; day-to-day use does not require it—the packaged indexes under `.cursor/skills/` are what the agent uses.
