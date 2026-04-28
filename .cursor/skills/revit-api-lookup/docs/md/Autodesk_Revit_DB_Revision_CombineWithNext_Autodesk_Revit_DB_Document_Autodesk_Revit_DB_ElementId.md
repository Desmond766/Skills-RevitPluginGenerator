---
kind: method
id: M:Autodesk.Revit.DB.Revision.CombineWithNext(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
source: html/9f2ee71b-6e13-c6a8-306a-cfe493c39f96.htm
---
# Autodesk.Revit.DB.Revision.CombineWithNext Method

Combines the specified Revision with the next Revision.

## Syntax (C#)
```csharp
public static ISet<ElementId> CombineWithNext(
	Document document,
	ElementId revisionId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The Document containing the Revisions.
- **revisionId** (`Autodesk.Revit.DB.ElementId`) - The Revision that should have its clouds and tags associated with the next Revision.

## Returns
The ids of all RevisionClouds that were reassigned to the next Revision.

## Remarks
All RevisionClouds and tags associated with the specified Revision will be reassigned
 to the next Revision in the model and the specified Revision will be deleted from
 the model. The operation can only be performed if both the specified Revision and the
 next one are unissued.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - revisionId is not a valid Revision.
 -or-
 This operation cannot be performed because revisionId is an issued Revision.
 -or-
 revisionId cannot be combined with the next Revision because either revisionId is
 the last Revision or the next Revision has already been issued.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

