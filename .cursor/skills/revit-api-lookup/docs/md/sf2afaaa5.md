---
kind: property
id: P:Autodesk.Revit.DB.IFCExportOptions.WallAndColumnSplitting
source: html/114c1194-c977-bfbd-acae-d14266cfcc02.htm
---
# Autodesk.Revit.DB.IFCExportOptions.WallAndColumnSplitting Property

Option to allow division of multi-level walls and columns by levels.

## Syntax (C#)
```csharp
public bool WallAndColumnSplitting { get; set; }
```

## Remarks
This option will always be considered true when FileVersion is IFC-BCA.
 For other File Versions, default is false.

