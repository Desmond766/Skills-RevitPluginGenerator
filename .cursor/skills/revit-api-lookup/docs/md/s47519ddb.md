---
kind: method
id: M:Autodesk.Revit.DB.AlphanumericRevisionSettings.SetSequence(System.Collections.Generic.IList{System.String})
source: html/5d362974-b742-35d9-c628-10e793b7c1e1.htm
---
# Autodesk.Revit.DB.AlphanumericRevisionSettings.SetSequence Method

Sets the sequence of strings to be used as numbers for revisions with the Alphanumeric RevisionNumberType.

## Syntax (C#)
```csharp
public void SetSequence(
	IList<string> sequence
)
```

## Parameters
- **sequence** (`System.Collections.Generic.IList < String >`) - The sequence. The sequence strings cannot contain commas.

## Remarks
If there are more alphanumeric revisions than there are
 strings in the sequence, subsequent alphanumeric revisions will
 be assigned duplicated characters. For example, if the sequence
 provided were ["X", "Y"], the first alphanumeric revision would
 be shown as "X", the second as "Y", the third as "XX", then "YY",
 "XXX", etc.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Input sequence contains invalid entries.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

