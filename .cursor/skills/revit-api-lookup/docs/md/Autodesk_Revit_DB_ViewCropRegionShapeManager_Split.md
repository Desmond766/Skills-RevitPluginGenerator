---
kind: property
id: P:Autodesk.Revit.DB.ViewCropRegionShapeManager.Split
zh: 拆分、打断、分割
source: html/9fb6ad28-2917-3194-9b71-8fed8461d22b.htm
---
# Autodesk.Revit.DB.ViewCropRegionShapeManager.Split Property

**中文**: 拆分、打断、分割

Whether or not the view crop is split.

## Syntax (C#)
```csharp
public bool Split { get; }
```

## Remarks
This property reflects the actual visual split of the crop region.
 Thus, if the view has non-rectangular crop shape set, this property is false.

