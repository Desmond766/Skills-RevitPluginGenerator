---
kind: method
id: M:Autodesk.Revit.DB.Revision.ReorderRevisionSequence(Autodesk.Revit.DB.Document,System.Collections.Generic.IList{Autodesk.Revit.DB.ElementId})
source: html/e3b46f87-ccb2-a706-ec4e-e24cbd601732.htm
---
# Autodesk.Revit.DB.Revision.ReorderRevisionSequence Method

Reorders the sequence of Revisions in the project.

## Syntax (C#)
```csharp
public static void ReorderRevisionSequence(
	Document document,
	IList<ElementId> newSequence
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document in which the Revision sequence should be reordered.
- **newSequence** (`System.Collections.Generic.IList < ElementId >`) - The new sequence of Revisions.

## Remarks
This method allows the caller to change the sequence of the Revisions within the project by specifying the
 new sequence. The specified sequence must include every Revision in the project exactly once.
Note that changing the sequence of Revisions can change the SequenceNumber and RevisionNumber
 of Revisions that have already been issued.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - newSequence does not contain every Revision exactly once.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

