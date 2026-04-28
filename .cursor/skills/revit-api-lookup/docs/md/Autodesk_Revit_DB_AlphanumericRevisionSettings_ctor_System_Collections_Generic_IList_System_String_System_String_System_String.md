---
kind: method
id: M:Autodesk.Revit.DB.AlphanumericRevisionSettings.#ctor(System.Collections.Generic.IList{System.String},System.String,System.String)
source: html/ce102195-68eb-adeb-1488-6c66d82cdff1.htm
---
# Autodesk.Revit.DB.AlphanumericRevisionSettings.#ctor Method

Constructs an AlphanumericRevisionSettings object.

## Syntax (C#)
```csharp
public AlphanumericRevisionSettings(
	IList<string> sequence,
	string prefix,
	string suffix
)
```

## Parameters
- **sequence** (`System.Collections.Generic.IList < String >`) - The custom sequence to be used as numbers for revisions with the
 Alphanumeric RevisionNumberType. If there are more alphanumeric revisions than there are
 strings in the sequence, subsequent alphanumeric revisions will
 be assigned duplicated characters. For example, if the sequence
 provided were ["X", "Y"], the first alphanumeric revision would
 be shown as "X", the second as "Y", the third as "XX", then "YY",
 "XXX", etc.
- **prefix** (`System.String`) - The prefix string for each revision number in the sequence.
- **suffix** (`System.String`) - The suffix string for each revision number in the sequence.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Input sequence contains invalid entries.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

