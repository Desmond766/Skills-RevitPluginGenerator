# Revit Add-in Skills for Cursor

Use **Cursor** with plain English to scaffold Revit 2024 C# add-ins, look up the API, build, and install into **your own** `%AppData%\Autodesk\Revit\Addins\2024\`.

This repo ships **Cursor Agent Skills** under [`.cursor/skills/`](.cursor/skills/) so everyone on your team gets the same prompts, lookup index, and deploy script—clone (or unzip), open the folder in Cursor, and start asking.

## What you get

| Skill | Role |
| --- | --- |
| [`revit-addin-scaffold`](.cursor/skills/revit-addin-scaffold/SKILL.md) | New `.csproj`, `.addin`, and `IExternalCommand` / `IExternalApplication` from a natural-language request. |
| [`revit-api-lookup`](.cursor/skills/revit-api-lookup/SKILL.md) | API signatures and usage via the packaged index ([`symbols.jsonl`](.cursor/skills/revit-api-lookup/docs/symbols.jsonl) and markdown sidecars). No CHM download required for normal use. |
| [`revit-addin-build-deploy`](.cursor/skills/revit-addin-build-deploy/SKILL.md) | MSBuild and copy the DLL plus a rewritten `.addin` into your Revit 2024 user Addins folder. The deploy script lives **inside** this skill: [`deploy-addin.ps1`](.cursor/skills/revit-addin-build-deploy/scripts/deploy-addin.ps1). |

The agent chooses skills from their descriptions—you do not run them by name.

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

## Quick start

1. **Get the repo** — `git clone <your-repo-url>` or unzip a copy your team distributes.
2. **Open the repo root in Cursor** so `.cursor/skills/` is loaded.
3. **Ask for an add-in in chat**, for example: *"Create a Revit add-in that exports all rooms in the active view to CSV with number, name, and area in m²."*

The agent should scaffold, look up APIs, implement, run build/deploy, and place the add-in under your user Addins folder. Restart Revit 2024 and look under **Add-Ins → External Tools** (or your ribbon if the add-in registers one).

---

## How Revit loads the add-in

1. The build-deploy flow compiles the project and writes the DLL and a **rewritten** `.addin` under `%AppData%\Autodesk\Revit\Addins\2024\`. Revit reads that folder at startup.
2. The manifest’s `<Assembly>` path is set to **your** deployed DLL so paths are not shared blindly between machines.
3. For **all users on one PC**, you can target `C:\ProgramData\Autodesk\Revit\Addins\2024\` if your team’s process allows (often needs admin). See the build-deploy skill for flags like `-AddinsDir`.

To **share a built add-in** without rebuilding: give someone the `.dll` + `.addin` and they copy both into their own user Addins folder—no need to run the deploy script on their side.

---

## Sharing the skills with your team

**Git (recommended)** — Push this repo to GitHub / GitLab / Azure DevOps. Teammates clone and open in Cursor; `git pull` brings skill updates.

**Zip** — Pack at least:

- `.cursor/` (entire tree, so skills and packaged indexes stay together)
- `README.md` and `.gitignore` if you use them

There is **no** root `setup.ps1` in this distribution; onboarding is: install prerequisites, open the folder in Cursor, and go.

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
│       ├── revit-addin-scaffold/   SKILL.md, template/, patterns.md, samples-index/
│       ├── revit-api-lookup/      SKILL.md, scripts/, docs/ (packaged index + md)
│       └── revit-addin-build-deploy/  SKILL.md, scripts/deploy-addin.ps1
├── .gitignore
└── README.md
```

Maintainer-only tooling (regenerating the API index from CHM, mining legacy code into `samples-index/`, etc.) is **not** part of this repo; day-to-day use does not require it—the packaged indexes under `.cursor/skills/` are what Cursor uses.
