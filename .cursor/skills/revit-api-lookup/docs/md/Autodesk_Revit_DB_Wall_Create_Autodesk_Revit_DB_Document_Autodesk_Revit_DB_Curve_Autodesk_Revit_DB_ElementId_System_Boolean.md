---
kind: method
id: M:Autodesk.Revit.DB.Wall.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.Curve,Autodesk.Revit.DB.ElementId,System.Boolean)
zh: 创建、新建、生成、建立、新增
source: html/4a42066c-bc44-0f99-566c-4e8327bc3bfa.htm
---
# Autodesk.Revit.DB.Wall.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new rectangular profile wall within the project using the default wall style.

## Syntax (C#)
```csharp
public static Wall Create(
	Document document,
	Curve curve,
	ElementId levelId,
	bool structural
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document in which the new wall is created.
- **curve** (`Autodesk.Revit.DB.Curve`) - A curve representing the base line of the wall.
- **levelId** (`Autodesk.Revit.DB.ElementId`) - Id of the level on which the wall is to be placed.
- **structural** (`System.Boolean`) - If set, specifies that the wall is structural in nature.

## Returns
If successful a new wall object within the project.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The curve argument is not valid for wall creation.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document has no open transaction.

