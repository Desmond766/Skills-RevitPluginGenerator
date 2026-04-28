---
kind: method
id: M:Autodesk.Revit.DB.View3D.OrientTo(Autodesk.Revit.DB.XYZ)
zh: 三维视图、3d视图
source: html/5f7c316e-62de-57fb-bb24-5ea6a8e52eaf.htm
---
# Autodesk.Revit.DB.View3D.OrientTo Method

**中文**: 三维视图、3d视图

Reorients the view to align with the forward direction.

## Syntax (C#)
```csharp
public void OrientTo(
	XYZ forwardDirection
)
```

## Parameters
- **forwardDirection** (`Autodesk.Revit.DB.XYZ`) - The forward direction.

## Remarks
This method adjusts the ViewOrientation to align with the input forward direction.
 The eye position will be automatically determined based on the shape of the
 viewing area and size of the model. The UpDirection will be aligned with the project Z axis.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - forwardDirection has zero length.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - View is locked and cannot be reoriented.

