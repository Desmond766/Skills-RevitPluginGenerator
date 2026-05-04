---
kind: method
id: M:Autodesk.Revit.DB.FormattedText.SetPlainText(Autodesk.Revit.DB.TextRange,System.String)
source: html/ef85472c-c691-77f8-5823-33da6ea43832.htm
---
# Autodesk.Revit.DB.FormattedText.SetPlainText Method

Sets the text with the given text in a plain text form in a range.

## Syntax (C#)
```csharp
public void SetPlainText(
	TextRange textRange,
	string plainText
)
```

## Parameters
- **textRange** (`Autodesk.Revit.DB.TextRange`) - The given text range.
- **plainText** (`System.String`) - The given text in a plain text form.

## Remarks
Any individual formatting present in the range before will be lost after applying this function
 and the text in the range will have uniform formatting.
 The given text will be inserted if the given text range is empty.
 The given text should have no more than 30,000 characters.
 The the resulting text may not exceed 30,000 characters.
 Newline characters ('\n') are not allowed.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - This start index of this text range is not within the text range identifying the entire text.
 -or-
 The end of this text range is not within the text range identifying the entire text.
 -or-
 plainText contains invalid characters such as a newline character.
 -or-
 plainText (excluding a carriage return character ('\r') at the end) has more than 30,000 characters.
 -or-
 Replacing the text in textRange with plainText will exceed 30,000 characters.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

