---
kind: property
id: P:Autodesk.Revit.DB.ACADExportOptions.NonplotSuffix
source: html/c83da56f-b0e1-5789-2b46-e76728ce5704.htm
---
# Autodesk.Revit.DB.ACADExportOptions.NonplotSuffix Property

If the MarkNonplotLayers attribute is set to true, all layers with names containing this suffix will be marked as non-plot.
 No action will be performed if the suffix is empty.

## Syntax (C#)
```csharp
public string NonplotSuffix { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

