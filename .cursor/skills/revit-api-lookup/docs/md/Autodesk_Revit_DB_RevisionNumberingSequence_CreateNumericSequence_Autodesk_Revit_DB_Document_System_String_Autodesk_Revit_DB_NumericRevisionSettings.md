---
kind: method
id: M:Autodesk.Revit.DB.RevisionNumberingSequence.CreateNumericSequence(Autodesk.Revit.DB.Document,System.String,Autodesk.Revit.DB.NumericRevisionSettings)
source: html/b3cc881b-67ea-8bf5-476e-ae9c5b9d455a.htm
---
# Autodesk.Revit.DB.RevisionNumberingSequence.CreateNumericSequence Method

Creates a new numeric revision numbering sequence in the document.

## Syntax (C#)
```csharp
public static RevisionNumberingSequence CreateNumericSequence(
	Document document,
	string name,
	NumericRevisionSettings settings
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document of the new revision numbering sequence.
- **name** (`System.String`) - The name for the revision numbering sequence.
- **settings** (`Autodesk.Revit.DB.NumericRevisionSettings`) - The numeric settings for the revision numbering sequence.

## Returns
The newly created revision numbering sequence.

## Remarks
The new revision numbering sequence will not be assigned to any revision.
 Use `Revision.SetRevisionNumberingSequenceId` to apply the sequence to a revision.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - document is not a project document.
 -or-
 name is an empty string or contains only whitespace.
 -or-
 name cannot include prohibited characters, such as "{, }, [, ], |, ;, less-than sign, greater-than sign, ?, `, ~".
 -or-
 settings is not a valid NumericRevisionSettings.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document has no open transaction.

