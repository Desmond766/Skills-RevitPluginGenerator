---
kind: method
id: M:Autodesk.Revit.DB.Structure.LineLoad.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.Curve,Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.Structure.LineLoadType)
zh: 创建、新建、生成、建立、新增
source: html/6f4e235f-8aed-5f41-6d85-024e556dcb17.htm
---
# Autodesk.Revit.DB.Structure.LineLoad.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new custom line load within the project.

## Syntax (C#)
```csharp
public static LineLoad Create(
	Document document,
	ElementId hostElemId,
	Curve curve,
	XYZ forceVector1,
	XYZ momentVector1,
	LineLoadType symbol
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - Document to which new line load will be added.
- **hostElemId** (`Autodesk.Revit.DB.ElementId`) - The analytical host element for the line Load.
- **curve** (`Autodesk.Revit.DB.Curve`) - Curve of the line load.
- **forceVector1** (`Autodesk.Revit.DB.XYZ`) - The applied 3d force vector.
- **momentVector1** (`Autodesk.Revit.DB.XYZ`) - The applied 3d moment vector.
- **symbol** (`Autodesk.Revit.DB.Structure.LineLoadType`) - The symbol of the LineLoad. Set Nothing nullptr a null reference ( Nothing in Visual Basic) to use default type.

## Returns
If successful, returns the newly created LineLoad, Nothing nullptr a null reference ( Nothing in Visual Basic) otherwise.

## Remarks
The curve must be bounded.
 The curve can be:
 Line Arc Ellipse

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The element hostElemId does not exist in the document
 -or-
 hostElemId is not permitted for this type of load.
 -or-
 The provided curve is not supported.
 -or-
 The input curve is not bound.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentsInconsistentException** - Thrown when all force and moment vectors are equal zero.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown if type could not be set for newly created line load.

