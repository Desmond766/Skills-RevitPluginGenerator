---
kind: method
id: M:Autodesk.Revit.DB.FormattedText.SetListStartNumber(Autodesk.Revit.DB.TextRange,System.Int32)
source: html/f82173d6-552d-d9c3-e0b8-e6a1805bdb10.htm
---
# Autodesk.Revit.DB.FormattedText.SetListStartNumber Method

Sets the list start number on the paragraphs in a given text range.

## Syntax (C#)
```csharp
public void SetListStartNumber(
	TextRange textRange,
	int value
)
```

## Parameters
- **textRange** (`Autodesk.Revit.DB.TextRange`) - The given text range.
- **value** (`System.Int32`) - The list start number to be set on the text range.

## Remarks
List start number is the number of the first paragraph in a numbered list.
List start number can be set on paragraphs of type ArabicNumbers ,
 LowerCaseLetters and UpperCaseLetters .
 List start number can only be set for top-level paragraphs in a list;
 that is, they cannot be set to paragraphs which are part of a sub-list.
For paragraphs of type LowerCaseLetters and UpperCaseLetters 
 the list start number represents the letter in the order it appears in the alphabet.
 For example, for paragraphs of type LowerCaseLetters ,
 list start number of 2 will result in a list start "b.";
 list start number of 27 will result in a list start "aa.".
Adjoining paragraphs which have a list type other than None 
 are considered part of a numbered list.
 Changing the list start number of numbered paragraphs
 will cause changes to the numbers of the rest of the paragraphs in the same list.
This function applies the list start number to the given range.
 The list start number must be in the range given by the methods
 GetMinimumListStartNumber () () () and
 GetMaximumListStartNumber () () () .

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - This start index of this text range is not within the text range identifying the entire text.
 -or-
 The end of this text range is not within the text range identifying the entire text.
 -or-
 This list start number is not valid.
 A valid value must be in the range given by the methods
 GetMinimumListStartNumber () () () and
 GetMaximumListStartNumber () () () .
 -or-
 Cannot set list start number on this text range. The range contains paragraphs on which list start number cannot be set.
 List start number can be set on pararaphs of type ArabicNumbers ,
 LowerCaseLetters and UpperCaseLetters .
 List start number can only be set for top-level paragraphs in a list;
 that is, they cannot be set to paragraphs which are part of a sub-list.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

