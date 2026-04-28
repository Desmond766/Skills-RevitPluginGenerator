---
kind: property
id: P:Autodesk.Revit.DB.ViewCropRegionShapeManager.ShapeSet
source: html/4e4ddc06-f889-b955-a22d-c870c00526cc.htm
---
# Autodesk.Revit.DB.ViewCropRegionShapeManager.ShapeSet Property

Whether or not the view crop has a non-rectangular shape set.

## Syntax (C#)
```csharp
public bool ShapeSet { get; }
```

## Remarks
This property reflects the actual shape of the crop region.
 Thus, if this property is true the view Split property is false.

