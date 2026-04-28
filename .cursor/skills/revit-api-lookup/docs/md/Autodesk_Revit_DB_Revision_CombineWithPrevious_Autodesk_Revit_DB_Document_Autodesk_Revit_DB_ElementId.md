---
kind: method
id: M:Autodesk.Revit.DB.Revision.CombineWithPrevious(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
source: html/e66cf817-a4c4-ce4e-fa79-b7359000d24c.htm
---
# Autodesk.Revit.DB.Revision.CombineWithPrevious Method

Combines the specified Revision with the previous Revision.

## Syntax (C#)
```csharp
public static ISet<ElementId> CombineWithPrevious(
	Document document,
	ElementId revisionId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The Document containing the Revisions.
- **revisionId** (`Autodesk.Revit.DB.ElementId`) - The Revision that should have its clouds and tags associated with the previous Revision.

## Returns
The ids of all RevisionClouds that were reassigned to the previous Revision.

## Remarks
All RevisionClouds and tags associated with the specified Revision will be reassigned
 to the previous Revision in the model and the specified Revision will be deleted from
 the model. The operation can only be performed if both the specified Revision and the
 previous one are unissued.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - revisionId is not a valid Revision.
 -or-
 This operation cannot be performed because revisionId is an issued Revision.
 -or-
 revisionId cannot be combined with the previous Revision because either revisionId is
 the first Revision or the previous Revision has already been issued.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

