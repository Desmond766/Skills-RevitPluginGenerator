---
kind: method
id: M:Autodesk.Revit.DB.Wall.Create(Autodesk.Revit.DB.Document,System.Collections.Generic.IList{Autodesk.Revit.DB.Curve},Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId,System.Boolean,Autodesk.Revit.DB.XYZ)
zh: 创建、新建、生成、建立、新增
source: html/6c247699-c8e5-91df-67f7-470d10fa7ba3.htm
---
# Autodesk.Revit.DB.Wall.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a non rectangular profile wall within the project using the specified wall type and normal vector.

## Syntax (C#)
```csharp
public static Wall Create(
	Document document,
	IList<Curve> profile,
	ElementId wallTypeId,
	ElementId levelId,
	bool structural,
	XYZ normal
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document in which the new wall is created.
- **profile** (`System.Collections.Generic.IList < Curve >`) - An array of planar curves that represent the vertical profile of the wall.
- **wallTypeId** (`Autodesk.Revit.DB.ElementId`) - Id of the wall type to be used by the new wall instead of the default type.
- **levelId** (`Autodesk.Revit.DB.ElementId`) - Id of the level on which the wall is to be placed.
- **structural** (`System.Boolean`) - If set, specifies that the wall is structural in nature.
- **normal** (`Autodesk.Revit.DB.XYZ`) - A vector that must be perpendicular to the profile which dictates which side of the wall is considered to be inside and outside.

## Returns
If successful a new wall object within the project.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The input profile contains at least one helical curve and is not supported for this operation.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Failed to create the wall.
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document has no open transaction.

