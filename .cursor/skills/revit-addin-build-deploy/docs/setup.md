# Setup (build & deploy)

## Machine requirements

- **Revit 2024** at `C:\Program Files\Autodesk\Revit 2024\` (or set `$env:RevitInstallPath` before build).
- **MSBuild**: on `PATH`, or Visual Studio **vswhere**, or **`dotnet`** with the **.NET Framework 4.8 targeting pack** for SDK-style `net48` projects.
- **Close Revit** before copying a new DLL into the user Addins folder (avoids file locks).

## Skill layout

See `../templates/config.yaml` for default deploy options. Run the deploy script from the **workspace root** (paths in `SKILL.md` are relative to it).

```powershell
powershell -ExecutionPolicy Bypass -File .cursor/skills/revit-addin-build-deploy/scripts/deploy-addin.ps1 -ProjectPath "path\to\YourAddin.csproj"
```
