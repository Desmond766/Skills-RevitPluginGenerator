---
kind: method
id: M:Autodesk.Revit.DB.Structure.LineLoad.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,System.Int32,Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.Structure.LineLoadType)
zh: 创建、新建、生成、建立、新增
source: html/f4ad118f-7ba8-3050-2738-7ecc1704f0fb.htm
---
# Autodesk.Revit.DB.Structure.LineLoad.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new hosted line load within the project.

## Syntax (C#)
```csharp
public static LineLoad Create(
	Document document,
	ElementId hostElemId,
	int curveIndex,
	XYZ forceVector1,
	XYZ momentVector1,
	LineLoadType symbol
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - Document to which new line load will be added.
- **hostElemId** (`Autodesk.Revit.DB.ElementId`) - The analytical host element for the line Load.
- **curveIndex** (`System.Int32`) - The index of a curve in analytical surface element starting from 0.
 Use [!:Autodesk::Revit::DB::Structure::AnalyticalSurfaceBase::GetOuterContour] method to obtain appropriate curve index.
 Curve index has a unique value in analytical element. The index should be obtain by iteration through all curves in all loops.
- **forceVector1** (`Autodesk.Revit.DB.XYZ`) - The applied 3d force vector.
- **momentVector1** (`Autodesk.Revit.DB.XYZ`) - The applied 3d moment vector.
- **symbol** (`Autodesk.Revit.DB.Structure.LineLoadType`) - The symbol of the LineLoad. Set Nothing nullptr a null reference ( Nothing in Visual Basic) to use default type.

## Returns
If successful, returns the newly created LineLoad, Nothing nullptr a null reference ( Nothing in Visual Basic) otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The element hostElemId does not exist in the document
 -or-
 hostElemId is not permitted for this type of load.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentsInconsistentException** - Thrown when all force and moment vectors are equal zero.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown if type could not be set for newly created line load.

