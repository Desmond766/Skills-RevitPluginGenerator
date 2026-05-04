# Troubleshooting (build & deploy)

| Symptom | What to check |
|--------|----------------|
| Add-in missing in Revit | Confirm `.addin` and DLL exist under `%AppData%\Autodesk\Revit\Addins\2024\`; open `.addin` and verify `<Assembly>` points at the deployed DLL. |
| Copy failed / IOException | Revit is holding the DLL — close Revit and redeploy. |
| MSBuild errors | `TargetFramework` must be `net48`, `PlatformTarget` **x64**; `RevitAPI.dll` / `RevitAPIUI.dll` must **not** be Copy Local. |
| Silent load failure | Read the latest journal under `%LocalAppData%\Autodesk\Revit\Autodesk Revit 2024\Journals\` for `Exception` or the add-in name. |
| Duplicate commands | Each `<AddIn>` needs a **unique** `AddInId` GUID. |
