---
kind: method
id: M:Autodesk.Revit.DB.Floor.GetNormalAtVerticalProjectionPoint(Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.FloorFace)
zh: 楼板、板、地板
source: html/f27752c0-4c9e-df9f-e3cd-34a1465cf11a.htm
---
# Autodesk.Revit.DB.Floor.GetNormalAtVerticalProjectionPoint Method

**中文**: 楼板、板、地板

Return a surface normal on either the top or bottom face of a floor slab at a point corresponding to the vertical 
projection of an arbitrary point in project space.

## Syntax (C#)
```csharp
public XYZ GetNormalAtVerticalProjectionPoint(
	XYZ modelLocation,
	FloorFace floorFace
)
```

## Parameters
- **modelLocation** (`Autodesk.Revit.DB.XYZ`) - A point in project coordinates whose vertical projection will determine the location at which
the normal will be taken.
- **floorFace** (`Autodesk.Revit.DB.FloorFace`) - A flag determining whether the top or bottom face of the floor should be used.

## Returns
Normal vector on the slab at the projection point.

## Remarks
If the floor is shape edited, the floor location at which we attempt to take the normal must be within the boundaries 
of a face on the slab. Otherwise the method will return Nothing nullptr a null reference ( Nothing in Visual Basic) .

