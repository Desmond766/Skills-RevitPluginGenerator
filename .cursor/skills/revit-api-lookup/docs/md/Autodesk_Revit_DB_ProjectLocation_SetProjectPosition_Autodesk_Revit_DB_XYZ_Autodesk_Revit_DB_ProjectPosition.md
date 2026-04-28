---
kind: method
id: M:Autodesk.Revit.DB.ProjectLocation.SetProjectPosition(Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.ProjectPosition)
source: html/ff73932a-dae4-37b3-5b4d-584e4bb95e2a.htm
---
# Autodesk.Revit.DB.ProjectLocation.SetProjectPosition Method

Sets the coordinates of a point in the ProjectLocation's coordinate system.

## Syntax (C#)
```csharp
public void SetProjectPosition(
	XYZ point,
	ProjectPosition position
)
```

## Parameters
- **point** (`Autodesk.Revit.DB.XYZ`)
- **position** (`Autodesk.Revit.DB.ProjectPosition`)

## Remarks
When setting this value, the transformations applied to the location are modified such that the passed point
 becomes the specified North/South, East/West and Elevation, and the coordinate transform will have the designated
 angular rotation. This is similar to the Revit command "Specify Coordinates at Point".

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Unable to use the project position's transform to calculate the point.

