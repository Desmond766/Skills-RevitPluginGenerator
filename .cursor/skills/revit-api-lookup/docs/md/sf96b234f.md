---
kind: property
id: P:Autodesk.Revit.DB.ViewCropRegionShapeManager.RightAnnotationCropOffset
source: html/3858d0de-caaa-8e31-545c-8c0a3c8fb0f2.htm
---
# Autodesk.Revit.DB.ViewCropRegionShapeManager.RightAnnotationCropOffset Property

The offset from the right of the view crop that determines the location of the annotation crop right boundary.

## Syntax (C#)
```csharp
public double RightAnnotationCropOffset { get; set; }
```

## Remarks
This value must be a non-negative length in view units.
 Default value is 1/12' (1"), minimal value is 1/96' (1/8").
 To get offset in model units, multiply the value by the view scale.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The given value for offset must be non-negative.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - View is not allowed to have an annotation crop.

