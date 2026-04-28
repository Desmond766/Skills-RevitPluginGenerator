---
kind: method
id: M:Autodesk.Revit.DB.Structure.PointLoad.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.Structure.AnalyticalElementSelector,Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.Structure.PointLoadType)
zh: 创建、新建、生成、建立、新增
source: html/f843d229-c621-6b79-e77f-77064ea7de30.htm
---
# Autodesk.Revit.DB.Structure.PointLoad.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new hosted point load within the project.

## Syntax (C#)
```csharp
public static PointLoad Create(
	Document document,
	ElementId hostElemId,
	AnalyticalElementSelector selector,
	XYZ forceVector,
	XYZ momentVector,
	PointLoadType symbol
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - Document to which new point load will be added.
- **hostElemId** (`Autodesk.Revit.DB.ElementId`) - The AnalyticalMember host element for the point Load.
- **selector** (`Autodesk.Revit.DB.Structure.AnalyticalElementSelector`) - The start or end point of the Analytical Member element.
- **forceVector** (`Autodesk.Revit.DB.XYZ`) - The applied 3d force vector.
- **momentVector** (`Autodesk.Revit.DB.XYZ`) - The applied 3d moment vector.
- **symbol** (`Autodesk.Revit.DB.Structure.PointLoadType`) - The symbol of the PointLoad. Set Nothing nullptr a null reference ( Nothing in Visual Basic) to use default type.

## Returns
If successful, returns the newly created PointLoad, Nothing nullptr a null reference ( Nothing in Visual Basic) otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The element hostElemId does not exist in the document
 -or-
 hostElemId is not permitted for this type of load.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.ArgumentsInconsistentException** - Thrown when force and moment vectors are equal zero.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown if type could not be set for newly created point load.

