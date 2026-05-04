---
kind: method
id: M:Autodesk.Revit.DB.Architecture.Railing.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.CurveLoop,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId)
zh: 创建、新建、生成、建立、新增
source: html/34a36770-964a-60eb-5ad7-c013913dfd05.htm
---
# Autodesk.Revit.DB.Architecture.Railing.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new railing by specifying the railing path in the project document.

## Syntax (C#)
```csharp
public static Railing Create(
	Document document,
	CurveLoop curveLoop,
	ElementId railingTypeId,
	ElementId baseLevelId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **curveLoop** (`Autodesk.Revit.DB.CurveLoop`) - The railing path along which the new railing will be created.
 The curveLoop should be continuous with curves which are only bounded lines and arcs on the same horizontal plane.
 It also has to have maximum two curves meet in one end point.
- **railingTypeId** (`Autodesk.Revit.DB.ElementId`) - The railing type of the new railing to be created.
- **baseLevelId** (`Autodesk.Revit.DB.ElementId`) - The base level on which the new railing will be created.

## Returns
The new railing instance if creation was successful, otherwise Nothing nullptr a null reference ( Nothing in Visual Basic) .

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The curveLoop must be a single connected path, located on the same horizontal plane and defined using lines or arcs only.
 It also has to have maximum two curves meet in one end point.
 -or-
 The railingTypeId is not a railing type.
 -or-
 The ElementId baseLevelId is not a Level.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document has no open transaction.

