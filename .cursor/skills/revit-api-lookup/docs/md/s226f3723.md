---
kind: property
id: P:Autodesk.Revit.DB.Category.HasMaterialQuantities
source: html/c28ed2ba-c91a-7eb9-94dd-48f802a41c8a.htm
---
# Autodesk.Revit.DB.Category.HasMaterialQuantities Property

Identifies if elements of the category are able to report what materials they contain in what quantities.

## Syntax (C#)
```csharp
public bool HasMaterialQuantities { get; }
```

## Remarks
Get materials via the Element' property Materials;
Get quantities via methods GetMaterialArea and GetMaterialVolume.

