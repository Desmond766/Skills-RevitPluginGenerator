---
kind: property
id: P:Autodesk.Revit.DB.ACADExportOptions.MarkNonplotLayers
source: html/15af29b2-8654-1a8c-a701-849be9bc9288.htm
---
# Autodesk.Revit.DB.ACADExportOptions.MarkNonplotLayers Property

If true and the nonplot layer suffix is not empty, all layers whose names contain that suffix will be marked as non-plot.

## Syntax (C#)
```csharp
public bool MarkNonplotLayers { get; set; }
```

## Remarks
A typical use would be to mark as non-plot all layers containing -NPLT.
 Default value is false

