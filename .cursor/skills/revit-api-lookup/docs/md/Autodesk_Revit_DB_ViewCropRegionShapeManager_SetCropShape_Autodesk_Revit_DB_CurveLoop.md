---
kind: method
id: M:Autodesk.Revit.DB.ViewCropRegionShapeManager.SetCropShape(Autodesk.Revit.DB.CurveLoop)
source: html/548c4181-2779-40a2-8276-b7a43a85a161.htm
---
# Autodesk.Revit.DB.ViewCropRegionShapeManager.SetCropShape Method

Sets the boundary of the view's crop to the specified shape.

## Syntax (C#)
```csharp
public void SetCropShape(
	CurveLoop boundary
)
```

## Parameters
- **boundary** (`Autodesk.Revit.DB.CurveLoop`) - The crop boundary.

## Remarks
Depending on the shape of the argument, view's crop is set to be either rectangular or non-rectangular.
 If the crop is set to be rectangular and it is also split, then the multiple view regions will be displayed for the view,
 with the same proportions as the split prior to the change, but adjusted to the new rectangular shape.
This Method is reserved for setting crop shape in views that allow non-rectangular crop shapes - see property CanHaveShape .
 For views that don't allow non-rectangular crop shapes (e.g. View3D ), please use property CropBox for that purpose.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Boundary in boundary should represent one closed curve loop without self-intersections,
 consisting of non-zero length straight lines in a plane parallel to the view plane.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The crop of the associated view is not permitted to have a non-rectangular shape.

