---
kind: method
id: M:Autodesk.Revit.DB.Structure.PointLoad.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.Structure.PointLoadType)
zh: 创建、新建、生成、建立、新增
source: html/93a5a733-454c-38a4-6096-652927c726ef.htm
---
# Autodesk.Revit.DB.Structure.PointLoad.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new custom hosted point load within the project using data at point.

## Syntax (C#)
```csharp
public static PointLoad Create(
	Document document,
	ElementId hostElemId,
	XYZ point,
	XYZ forceVector,
	XYZ momentVector,
	PointLoadType symbol
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - Document to which new point load will be added.
- **hostElemId** (`Autodesk.Revit.DB.ElementId`) - The AnalyticalElement host element for the point Load.
- **point** (`Autodesk.Revit.DB.XYZ`) - The position of point load, measured in decimal feet.
- **forceVector** (`Autodesk.Revit.DB.XYZ`) - The applied 3d force vector.
- **momentVector** (`Autodesk.Revit.DB.XYZ`) - The applied 3d moment vector.
- **symbol** (`Autodesk.Revit.DB.Structure.PointLoadType`) - The symbol of the PointLoad. Set Nothing nullptr a null reference ( Nothing in Visual Basic) to use default type.

## Returns
If successful, returns the newly created PointLoad, Nothing nullptr a null reference ( Nothing in Visual Basic) otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - hostElemId is not permitted for this type of load.
 -or-
 Thrown when work plane is not valid.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentsInconsistentException** - Thrown when force and moment vectors are equal zero.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown if type could not be set for newly created point load.

