---
kind: property
id: P:Autodesk.Revit.DB.RevisionNumberingSequence.SequenceName
source: html/443a595a-51e1-c93e-d32b-0986178c777d.htm
---
# Autodesk.Revit.DB.RevisionNumberingSequence.SequenceName Property

The name of this revision numbering sequence.

## Syntax (C#)
```csharp
public string SequenceName { get; set; }
```

## Remarks
This name appears in the Sheet Issues/Revisions dialog as a numbering choice for each revision.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: sequenceName is an empty string or contains only whitespace.
 -or-
 When setting this property: sequenceName cannot include prohibited characters, such as "{, }, [, ], |, ;, less-than sign, greater-than sign, ?, `, ~".
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

