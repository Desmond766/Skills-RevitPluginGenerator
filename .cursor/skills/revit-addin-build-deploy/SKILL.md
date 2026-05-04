---
name: revit-addin-build-deploy
description: Build a Revit 2024 C# add-in with MSBuild and install it to Revit's Addins folder so it loads on next Revit launch. Use with Cline when the user asks to build, compile, deploy, install, register, or test a Revit add-in, or when revit-addin-scaffold hands off a finished project.
---

# Revit Add-in Build & Deploy

Compile an SDK-style .NET Framework 4.8 Revit add-in and drop the DLL + `.addin` manifest into the user's saved deploy folder.

## Cline

- Turn on **Settings → Features → Skills** so Cline can load this skill on demand (metadata always visible; full instructions load when the task matches this skill’s `description`).
- Treat repo paths below as **relative to the workspace root**. This repository keeps skills under `.cursor/skills/`; commands use that layout unchanged.
- **First use**: ask the user where compiled add-ins should be deployed. Pass that folder with `-AddinsDir`; the script saves it in `%AppData%\RevitSkills\revit-addin-build-deploy.json` and reuses it for later builds.
- **Run** `deploy-addin.ps1` via the terminal tool from the workspace root (or pass absolute paths). Rely on script exit codes and stdout/stderr; paste only the lines the user needs to fix failures.
- **Do not** paste large logs into chat; summarize and quote the actionable MSBuild or copy error.
- Quick reference: [`docs/setup.md`](./docs/setup.md), [`docs/troubleshooting.md`](./docs/troubleshooting.md), deploy defaults in [`templates/config.yaml`](./templates/config.yaml).

## When to use this skill

Trigger on:
- "Build the add-in" / "编译这个插件" / "构建并部署"
- "Deploy / install / register it in Revit" / "部署到 Revit" / "安装到 Revit 的 Addins 目录"
- "Copy the addin manifest to Revit's Addins folder"
- Any hand-off from `revit-addin-scaffold` after code is ready.

## Bilingual prompt protocol

This skill's inputs/outputs are file paths and exit codes, so bilingual handling is light:

- Accept the above Chinese triggers as equivalent to the English ones.
- Pass through any Chinese project paths (`existingCodes\梁涛插件源代码\...`) unmodified — `deploy-addin.ps1` and MSBuild handle UTF-8 paths fine as long as PowerShell is invoked with the default console code page.
- When reporting status back to a Chinese-prompting user, translate the success/failure summary into Chinese. Do **not** translate tool output (MSBuild errors, file paths) — the user needs the literal strings to debug.

## Prerequisites

- Revit 2024 installed at `C:\Program Files\Autodesk\Revit 2024\`
- A builder — the script tries, in order:
  1. `msbuild` on PATH
  2. Visual Studio MSBuild located via `vswhere.exe`
  3. `dotnet` CLI (uses its bundled MSBuild; works on SDK-style csproj targeting `net48` when the .NET Framework 4.8 targeting pack is installed)
- .NET Framework 4.8 targeting pack at `C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8`
- Closed Revit before deploying (it holds locks on loaded DLLs)
- A saved deploy destination in `%AppData%\RevitSkills\revit-addin-build-deploy.json`, created automatically on first use

## Workflow

Copy this checklist:

```
- [ ] Step 1: If no saved deploy destination exists, ask the user where compiled add-ins should be placed
- [ ] Step 2: Build (Release x64, net48) via MSBuild
- [ ] Step 3: Rewrite the <Assembly> path in the .addin manifest to the deployed DLL location
- [ ] Step 4: Copy DLL + .addin to the saved deploy folder
- [ ] Step 5: Prompt user to (re)launch Revit
- [ ] Step 6: If it fails to appear, check Revit's Journal file
```

### Step 1 + 2 + 3: One command

```powershell
powershell -ExecutionPolicy Bypass -File .cursor/skills/revit-addin-build-deploy/scripts/deploy-addin.ps1 -ProjectPath "path\to\Project.csproj"
```

(Use `pwsh` instead of `powershell` if PowerShell 7 is installed.)

First run behavior:

- Ask the user: **"Where should compiled Revit add-ins be deployed?"**
- Pass the answer once with `-AddinsDir "C:\path\to\folder"`.
- The script saves that folder to `%AppData%\RevitSkills\revit-addin-build-deploy.json`.
- Future runs can omit `-AddinsDir`; the saved folder is reused automatically.
- If no saved folder exists and `-AddinsDir` is omitted, the script prompts in PowerShell and offers `%AppData%\Autodesk\Revit\Addins\2024\` as the default.

Flags:

| Flag | Default | Meaning |
|---|---|---|
| `-ProjectPath <csproj>` | *(required)* | Path to the SDK-style .csproj |
| `-Configuration` | `Release` | `Debug` or `Release` |
| `-RevitVersion` | `2024` | Revit version used only for the first-run default destination |
| `-AddinsDir` | saved user folder | Override destination and save it for future runs |
| `-SkipBuild` | off | Deploy existing bin output without rebuilding |

What the script does:
1. Restores + builds the project (`msbuild /t:Restore;Build /p:Configuration=...;Platform=x64`).
2. Finds the output DLL and the sibling `.addin` file.
3. Rewrites `<Assembly>...</Assembly>` inside the `.addin` to the absolute path of the deployed DLL.
4. Copies the DLL (and its PDB, if present) + the rewritten `.addin` to the saved deploy directory.

### Step 4: Launch Revit

Instruct the user: *"Open Revit 2024. Your add-in will appear under the ribbon tab / command you defined. First launch may show a trust prompt — click 'Always Load'."*

### Step 5: Debugging a failed load

If the command doesn't appear in Revit:

1. **Check the `.addin` landed** in the saved deploy folder. The saved path is in `%AppData%\RevitSkills\revit-addin-build-deploy.json`.
2. **Check the DLL path inside it** matches a real file.
3. **Check the Revit journal** — latest file in `%LocalAppData%\Autodesk\Revit\Autodesk Revit 2024\Journals\`. Grep it for the add-in name or `Exception`:

   ```powershell
   $latest = Get-ChildItem "$env:LocalAppData\Autodesk\Revit\Autodesk Revit 2024\Journals\*.txt" | Sort-Object LastWriteTime -Descending | Select-Object -First 1
   rg -i -- "addin|exception|failed" $latest.FullName | Select-Object -First 40
   ```

4. **Version mismatch**: confirm `TargetFramework=net48` and `PlatformTarget=x64` in the csproj.
5. **AddInId collision**: each `<AddIn>` needs a unique GUID; duplicates silently fail.

## Uninstall

```powershell
Remove-Item "$env:AppData\Autodesk\Revit\Addins\2024\<Name>.*" -Force
```

## What NOT to do

- Do **not** copy to `%ProgramData%\Autodesk\Revit\Addins\2024\` unless installing machine-wide — that requires admin and affects all users.
- Do **not** deploy while Revit is open; the DLL is locked and the copy will fail with `IOException`.
- Do **not** mark RevitAPI.dll / RevitAPIUI.dll as `Copy Local` — they must resolve from the Revit install.
