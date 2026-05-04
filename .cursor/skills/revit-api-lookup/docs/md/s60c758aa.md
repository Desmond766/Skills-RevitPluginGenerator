---
kind: method
id: M:Autodesk.Revit.DB.TextRange.#ctor(System.Int32,System.Int32)
source: html/97ab00e6-9f7c-e73f-4dd8-54addfb73654.htm
---
# Autodesk.Revit.DB.TextRange.#ctor Method

Constructs a TextRange with input start and length.

## Syntax (C#)
```csharp
public TextRange(
	int start,
	int length
)
```

## Parameters
- **start** (`System.Int32`)
- **length** (`System.Int32`)

## Remarks
The input value for start as well as length should not be negative.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The given value for start is negative.
 -or-
 The given value for length is negative.

