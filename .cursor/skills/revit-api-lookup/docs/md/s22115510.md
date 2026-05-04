---
kind: property
id: P:Autodesk.Revit.DB.ViewCropRegionShapeManager.BottomAnnotationCropOffset
source: html/052f9969-ce4e-40c5-8573-30c4db60a25f.htm
---
# Autodesk.Revit.DB.ViewCropRegionShapeManager.BottomAnnotationCropOffset Property

The offset from the bottom of the view crop that determines the location of the annotation crop bottom boundary.

## Syntax (C#)
```csharp
public double BottomAnnotationCropOffset { get; set; }
```

## Remarks
This value must be a non-negative length in view units.
 Default value is 1/12' (1"), minimal value is 1/96' (1/8").
 To get offset in model units, multiply the value by the view scale.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The given value for offset must be non-negative.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - View is not allowed to have an annotation crop.

