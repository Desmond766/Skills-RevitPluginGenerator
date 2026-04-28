---
kind: method
id: M:Autodesk.Revit.DB.Architecture.Railing.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.Architecture.RailingPlacementPosition)
zh: 创建、新建、生成、建立、新增
source: html/1c9de88b-8038-4ac9-37bd-9b6fd5e1f801.htm
---
# Autodesk.Revit.DB.Architecture.Railing.Create Method

**中文**: 创建、新建、生成、建立、新增

Automatically creates new railings with the specified railing type on all sides of a stairs or ramp element.

## Syntax (C#)
```csharp
public static ICollection<ElementId> Create(
	Document document,
	ElementId stairsOrRampId,
	ElementId railingTypeId,
	RailingPlacementPosition placePosition
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **stairsOrRampId** (`Autodesk.Revit.DB.ElementId`) - The stairs or ramp to which the new railing will host.
 The stairs or ramp should have no associated railings yet.
 If the stairs are a part of MultistoryStairs element railings will be populated on all levels.
- **railingTypeId** (`Autodesk.Revit.DB.ElementId`) - The railing type of the new railing to be created.
- **placePosition** (`Autodesk.Revit.DB.Architecture.RailingPlacementPosition`) - The placement position of the new railing.

## Returns
The new railing instances successfully created on the stairs.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The stairsOrRampId is not a stairs or ramp element.
 -or-
 The railingTypeId is not a railing type.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The stairsOrRampId already has associated railings or is in editing mode so association of railings is not permitted.
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document has no open transaction.

