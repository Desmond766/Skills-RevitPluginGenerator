---
kind: method
id: M:Autodesk.Revit.DB.FormattedText.Find(System.String,System.Int32,System.Boolean,System.Boolean)
source: html/79034f02-9ca0-ebe5-8d16-112d674dbdb4.htm
---
# Autodesk.Revit.DB.FormattedText.Find Method

Returns a text range identifying the first occurrence of the given string within the text,
 starting from a given index.

## Syntax (C#)
```csharp
public TextRange Find(
	string searchString,
	int startIndex,
	bool matchCase,
	bool matchWholeWord
)
```

## Parameters
- **searchString** (`System.String`) - The text to search for.
- **startIndex** (`System.Int32`) - The start index to search within the text.
- **matchCase** (`System.Boolean`) - True if the case must match when searching the formatted text, false to search in a case-insensitive manner.
- **matchWholeWord** (`System.Boolean`) - True if the match must be a whole word when searching the formatted text, false otherwise.

## Returns
The text range identified.

## Remarks
Returns an empty text range:
 if the given string cannot be found in the text. if the given start index is beyond the length of the entire text. 
 The search can be case-sensitive or case-insensitive.
 The search can be set to match whole words or part of words.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - searchString is an empty string.
 -or-
 searchString contains invalid characters such as a newline character.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The given value for startIndex is negative.

