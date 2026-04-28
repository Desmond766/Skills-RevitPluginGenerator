---
kind: property
id: P:Autodesk.Revit.DB.RevisionNumberingSequence.NumberType
source: html/40fa01d2-22a9-16aa-b363-ba9e1343aab6.htm
---
# Autodesk.Revit.DB.RevisionNumberingSequence.NumberType Property

Indicates the revision number type of the revision numbering sequence.

## Syntax (C#)
```csharp
public RevisionNumberType NumberType { get; }
```

## Remarks
This property can be used to figure out if a revision numbering sequence is numeric or alphanumeric.
 The returned RevisionNumberType is either RevisionNumberType::Numeric or RevisionNumberType::Alphanumeric.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This RevisionNumberingSequence doesn't own a valid revision settings for number type.

