---
kind: method
id: M:Autodesk.Revit.DB.FormattedText.#ctor(System.String)
source: html/86332d2f-1939-4985-f428-24ee8b19072e.htm
---
# Autodesk.Revit.DB.FormattedText.#ctor Method

Creates a new FormattedText object with unformatted text.

## Syntax (C#)
```csharp
public FormattedText(
	string plainText
)
```

## Parameters
- **plainText** (`System.String`) - The text in a plain text form.

## Remarks
The given text should have no more than 30,000 characters.
 Line feed characters ('/n') are not allowed.
 An empty string is allowed.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - plainText (excluding a carriage return character ('\r') at the end) has more than 30,000 characters.
 -or-
 plainText contains invalid characters such as a newline character.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

