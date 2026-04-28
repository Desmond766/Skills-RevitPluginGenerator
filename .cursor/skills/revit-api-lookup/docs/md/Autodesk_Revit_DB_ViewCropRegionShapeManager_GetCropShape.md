---
kind: method
id: M:Autodesk.Revit.DB.ViewCropRegionShapeManager.GetCropShape
source: html/36a98b08-72be-4b0a-99f6-4a765b85b15d.htm
---
# Autodesk.Revit.DB.ViewCropRegionShapeManager.GetCropShape Method

Gets the crop boundaries that are curently active.

## Syntax (C#)
```csharp
public IList<CurveLoop> GetCropShape()
```

## Returns
The crop boundaries.

## Remarks
This method returns a representation of the boundaries of the currently active crop for the associated view.
 If the view crop has a non-rectangular shape, the method returns that shape.
 Otherwise, if the view crop has been split, the method returns the multiple rectangular boundaries visible in the crop -
 note that this does not reflect any offsets that may have been applied to the boundary regions.
 If the crop is not split, this returns a single rectangle representing the crop.
 All coordinates are in the coordinate frame of the view.

