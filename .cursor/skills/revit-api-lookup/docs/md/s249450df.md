---
kind: method
id: M:Autodesk.Revit.DB.Structure.AreaLoad.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.Structure.AreaLoadType)
zh: 创建、新建、生成、建立、新增
source: html/e977990d-f0d6-520d-5846-3260e5f6ca60.htm
---
# Autodesk.Revit.DB.Structure.AreaLoad.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new hosted area load within the project.

## Syntax (C#)
```csharp
public static AreaLoad Create(
	Document document,
	ElementId hostElemId,
	XYZ forceVector,
	AreaLoadType symbol
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - Document to which new area load will be added.
- **hostElemId** (`Autodesk.Revit.DB.ElementId`) - The analytical surface host element id for the area Load.
- **forceVector** (`Autodesk.Revit.DB.XYZ`) - The force vector applied to the 1st reference point of the area load.
- **symbol** (`Autodesk.Revit.DB.Structure.AreaLoadType`) - The symbol of the AreaLoad. Set Nothing nullptr a null reference ( Nothing in Visual Basic) to use default type.

## Returns
If successful, returns an object of the newly created AreaLoad. Nothing nullptr a null reference ( Nothing in Visual Basic) is returned if the operation fails.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The element hostElemId does not exist in the document
 -or-
 hostElemId is not permitted for this type of load.
 -or-
 Thrown when force vector is equal zero.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown if type could not be set for newly created area load.

