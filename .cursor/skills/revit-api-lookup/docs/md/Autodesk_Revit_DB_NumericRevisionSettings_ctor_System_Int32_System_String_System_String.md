---
kind: method
id: M:Autodesk.Revit.DB.NumericRevisionSettings.#ctor(System.Int32,System.String,System.String)
source: html/b0ee7bc3-0e42-4dfd-bf2d-666b60c0289b.htm
---
# Autodesk.Revit.DB.NumericRevisionSettings.#ctor Method

Constructs a NumericRevisionSettings object.

## Syntax (C#)
```csharp
public NumericRevisionSettings(
	int startNumber,
	string prefix,
	string suffix
)
```

## Parameters
- **startNumber** (`System.Int32`) - The start number for the sequence.
- **prefix** (`System.String`) - The prefix string for each revision number in the sequence.
- **suffix** (`System.String`) - The suffix string for each revision number in the sequence.

## Remarks
The starting number parameter accepts any non-negative integer, and
 the prefix and suffix strings are allowed to be empty.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The given value for startNumber is negative.

