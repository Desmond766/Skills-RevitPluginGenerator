---
kind: method
id: M:Autodesk.Revit.DB.Wall.Create(Autodesk.Revit.DB.Document,System.Collections.Generic.IList{Autodesk.Revit.DB.Curve},System.Boolean)
zh: 创建、新建、生成、建立、新增
source: html/d2848332-daca-2bf1-4aca-21ea21937758.htm
---
# Autodesk.Revit.DB.Wall.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a non rectangular profile wall within the project using the default wall type.

## Syntax (C#)
```csharp
public static Wall Create(
	Document document,
	IList<Curve> profile,
	bool structural
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document in which the new wall is created.
- **profile** (`System.Collections.Generic.IList < Curve >`) - An array of planar curves that represent the vertical profile of the wall.
- **structural** (`System.Boolean`) - If set, specifies that the wall is structural in nature.

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

