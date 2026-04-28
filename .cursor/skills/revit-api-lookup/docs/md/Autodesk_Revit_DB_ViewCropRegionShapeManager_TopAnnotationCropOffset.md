---
kind: property
id: P:Autodesk.Revit.DB.ViewCropRegionShapeManager.TopAnnotationCropOffset
source: html/b2dce097-7b29-4a40-3b06-cac4cbc49081.htm
---
# Autodesk.Revit.DB.ViewCropRegionShapeManager.TopAnnotationCropOffset Property

The offset from the top of the view crop that determines the location of the annotation crop top boundary.

## Syntax (C#)
```csharp
public double TopAnnotationCropOffset { get; set; }
```

## Remarks
This value must be a non-negative length in view units.
 Default value is 1/12' (1"), minimal value is 1/96' (1/8").
 To get offset in model units, multiply the value by the view scale.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The given value for offset must be non-negative.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - View is not allowed to have an annotation crop.

