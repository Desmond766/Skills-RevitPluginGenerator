---
kind: property
id: P:Autodesk.Revit.DB.ViewCropRegionShapeManager.LeftAnnotationCropOffset
source: html/c1df4fe4-5897-2f90-405d-4a05542179e0.htm
---
# Autodesk.Revit.DB.ViewCropRegionShapeManager.LeftAnnotationCropOffset Property

The offset from the left of the view crop that determines the location of the annotation crop left boundary.

## Syntax (C#)
```csharp
public double LeftAnnotationCropOffset { get; set; }
```

## Remarks
This value must be a non-negative length in view units.
 Default value is 1/12' (1"), minimal value is 1/96' (1/8").
 To get offset in model units, multiply the value by the view scale.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The given value for offset must be non-negative.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - View is not allowed to have an annotation crop.

