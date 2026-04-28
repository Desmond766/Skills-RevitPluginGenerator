---
kind: method
id: M:Autodesk.Revit.DB.Floor.GetVerticalProjectionPoint(Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.FloorFace)
zh: 楼板、板、地板
source: html/7c9e72b2-c058-44cb-e355-4bf819b4371d.htm
---
# Autodesk.Revit.DB.Floor.GetVerticalProjectionPoint Method

**中文**: 楼板、板、地板

Return a surface point on either the top or bottom face of a floor slab corresponding to the vertical projection
of an arbitrary point in project space.

## Syntax (C#)
```csharp
public XYZ GetVerticalProjectionPoint(
	XYZ modelLocation,
	FloorFace floorFace
)
```

## Parameters
- **modelLocation** (`Autodesk.Revit.DB.XYZ`) - A point in project coordinates that will be projected to the slab top or bottom face.
- **floorFace** (`Autodesk.Revit.DB.FloorFace`) - A flag determining whether the top or bottom face of the floor should be used.

## Returns
Slab surface point for the vertically projected model point.

## Remarks
If the floor is shape edited, the surface location must be within the boundaries of a face on the slab. 
Otherwise the method will return Nothing nullptr a null reference ( Nothing in Visual Basic) .

