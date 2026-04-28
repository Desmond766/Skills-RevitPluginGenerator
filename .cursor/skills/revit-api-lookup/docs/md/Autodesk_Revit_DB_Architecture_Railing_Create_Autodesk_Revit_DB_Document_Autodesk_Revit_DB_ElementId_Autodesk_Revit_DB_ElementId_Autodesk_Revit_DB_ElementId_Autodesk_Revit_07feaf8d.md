---
kind: method
id: M:Autodesk.Revit.DB.Architecture.Railing.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.Architecture.RailingPlacementPosition)
zh: 创建、新建、生成、建立、新增
source: html/3fae650e-f453-914a-5f56-5077c3a10706.htm
---
# Autodesk.Revit.DB.Architecture.Railing.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates new railings with the specified railing type on all sides of a stairs instance in a MultistoryStairs element.

## Syntax (C#)
```csharp
public static ISet<ElementId> Create(
	Document document,
	ElementId multistoryStairsId,
	ElementId levelId,
	ElementId railingTypeId,
	RailingPlacementPosition placePosition
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **multistoryStairsId** (`Autodesk.Revit.DB.ElementId`) - The id of the MultistoryStairs that contains the stairs which will be the host of this railing.
 The stairs should have no associated railings yet.
- **levelId** (`Autodesk.Revit.DB.ElementId`) - The level of stairs on which the new railing will be created.
 The level should be one of levels defining the MultistoryStairs element.
- **railingTypeId** (`Autodesk.Revit.DB.ElementId`) - The railing type of the new railing to be created.
- **placePosition** (`Autodesk.Revit.DB.Architecture.RailingPlacementPosition`) - The placement position of the new railing.

## Returns
The new railing instances successfully created on the stairs.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The railingTypeId is not a railing type.
 -or-
 The ElementId levelId is not a Level.
 -or-
 The levelId is not a level of MultistoryStairs stairs element.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The multistoryStairsId already has associated railings or is in editing mode so association of railings is not permitted.
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document has no open transaction.

