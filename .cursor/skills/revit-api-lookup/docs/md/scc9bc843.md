---
kind: property
id: P:Autodesk.Revit.DB.IFC.IFCImportOptions.ForceImport
source: html/f9fcc2e6-4e4e-94bd-2646-801f7f487612.htm
---
# Autodesk.Revit.DB.IFC.IFCImportOptions.ForceImport Property

Force the IFC file to be imported regardless of an existing corresponding Revit file.

## Syntax (C#)
```csharp
public bool ForceImport { get; set; }
```

## Remarks
If this value is true (default), we will perform the import even if the existing corresponding Revit file is up-to-date.
 If this value is false, then we will re-use an existing RVT file if it is up-to-date.
 The intention is for ForceImport to be false during host file open while reloading links,
 and true during link reload via the Manage Links API.

