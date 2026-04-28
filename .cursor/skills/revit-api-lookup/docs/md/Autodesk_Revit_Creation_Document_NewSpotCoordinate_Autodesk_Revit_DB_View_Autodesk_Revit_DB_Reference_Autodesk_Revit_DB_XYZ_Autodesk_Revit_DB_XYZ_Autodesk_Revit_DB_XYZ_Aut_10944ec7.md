---
kind: method
id: M:Autodesk.Revit.Creation.Document.NewSpotCoordinate(Autodesk.Revit.DB.View,Autodesk.Revit.DB.Reference,Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.XYZ,System.Boolean)
zh: 文档、文件
source: html/c2efc79c-75ff-4505-ef3d-3db94a952227.htm
---
# Autodesk.Revit.Creation.Document.NewSpotCoordinate Method

**中文**: 文档、文件

Generate a new spot coordinate object within the project.

## Syntax (C#)
```csharp
public SpotDimension NewSpotCoordinate(
	View view,
	Reference reference,
	XYZ origin,
	XYZ bend,
	XYZ end,
	XYZ refPt,
	bool hasLeader
)
```

## Parameters
- **view** (`Autodesk.Revit.DB.View`) - The view in which the spot coordinate is to be visible.
- **reference** (`Autodesk.Revit.DB.Reference`) - The reference to which the spot coordinate is to be bound.
- **origin** (`Autodesk.Revit.DB.XYZ`) - The point which the spot coordinate evaluate.
- **bend** (`Autodesk.Revit.DB.XYZ`) - The bend point for the spot coordinate.
- **end** (`Autodesk.Revit.DB.XYZ`) - The end point for the spot coordinate.
- **refPt** (`Autodesk.Revit.DB.XYZ`) - The actual point on the reference which the spot coordinate evaluate.
- **hasLeader** (`System.Boolean`) - Indicate if it has leader or not.

## Returns
If successful a new spot dimension object, otherwise Nothing nullptr a null reference ( Nothing in Visual Basic) .

## Remarks
If the origin point is not on the reference, it'll be projected to the reference automatically. And the refPt 
 is projected point. If the reference is not valid or the point cannot be projected to
 reference correctly, an exception will be thrown

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown if the view does not exist in the given document.

