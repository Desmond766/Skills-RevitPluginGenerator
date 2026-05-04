---
kind: property
id: P:Autodesk.Revit.DB.IFC.IFCImportOptions.AutoJoin
source: html/abf3e142-3f21-9161-e799-7a6b6e3c30b0.htm
---
# Autodesk.Revit.DB.IFC.IFCImportOptions.AutoJoin Property

Enable or disable auto-join at the end of import.

## Syntax (C#)
```csharp
public bool AutoJoin { get; set; }
```

## Remarks
Enabling auto-join will join appropriate elements (e.g., walls, columns), but will take extra time and may fail.
 Disabling auto-join will allow some imports that otherwise fail.
 Default is true for Open IFC; it is ignored (and false) for Link IFC.

