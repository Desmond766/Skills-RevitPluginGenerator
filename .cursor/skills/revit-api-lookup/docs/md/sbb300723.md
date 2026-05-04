---
kind: property
id: P:Autodesk.Revit.DB.Revision.RevisionNumberingSequenceId
source: html/1ee59a94-2e37-b280-a8eb-20663a4f6143.htm
---
# Autodesk.Revit.DB.Revision.RevisionNumberingSequenceId Property

The id of the revision numbering sequence which controls this revision's numbering.

## Syntax (C#)
```csharp
public ElementId RevisionNumberingSequenceId { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: revisionNumberingSequenceId doesn't represent a RevisionNumberingSequence element.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: This operation cannot be performed on Revisions that have already been issued.

