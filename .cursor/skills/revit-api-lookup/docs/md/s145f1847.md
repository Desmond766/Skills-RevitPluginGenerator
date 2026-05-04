---
kind: method
id: M:Autodesk.Revit.DB.ProjectLocation.GetProjectPosition(Autodesk.Revit.DB.XYZ)
source: html/45724712-d710-eb12-5a48-63a31a54f09f.htm
---
# Autodesk.Revit.DB.ProjectLocation.GetProjectPosition Method

Gets the coordinates of a point in the ProjectLocation's coordinate system.

## Syntax (C#)
```csharp
public ProjectPosition GetProjectPosition(
	XYZ point
)
```

## Parameters
- **point** (`Autodesk.Revit.DB.XYZ`)

## Remarks
When getting this value, the North/South, East/West, and Elevation values report the coordinates of the point
 similar to the Revit command "Report Shared Coordinates". To get the values of the transformations applied by this
 project location, pass XYZ.Zero. If the project has acquired shared coordinates from a linked model, the shared coordinate transformation will
 be reflected in the coordinates of the transformed point returned by this property.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Unable to use the project position's transform to calculate the point.

