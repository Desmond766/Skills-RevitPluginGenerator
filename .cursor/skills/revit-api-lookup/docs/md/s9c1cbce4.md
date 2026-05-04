---
kind: method
id: M:Autodesk.Revit.DB.FormattedText.SetListType(Autodesk.Revit.DB.TextRange,Autodesk.Revit.DB.ListType)
source: html/c0bb9933-9825-a28a-a09c-8b319f089b36.htm
---
# Autodesk.Revit.DB.FormattedText.SetListType Method

Sets the ListType of a paragraph.

## Syntax (C#)
```csharp
public void SetListType(
	TextRange textRange,
	ListType listType
)
```

## Parameters
- **textRange** (`Autodesk.Revit.DB.TextRange`) - The given text range.
- **listType** (`Autodesk.Revit.DB.ListType`) - The ListType to set on the paragraph.

## Remarks
This function applies the ListType 
 to all paragraphs contained in the given range.
The following ListType options are available:
 Bullet ArabicNumbers LowerCaseLetters UpperCaseLetters 
 Set the list type to None 
 if the paragraph should not be in a list.
The list type cannot be set to Mixed .
Paragraphs with a ListType other than None are considered
 to be 'list' paragraphs.
Consecutive list paragraphs with the same indentation level are treated as part of the same list.
 A list ends when a list paragraph is followed by
 a paragraph that has None or a list paragraph that has a lower indentation level, (i.e. is indented less) 
 Note that a list will continue uninterrupted after list paragraphs that have higher indentation level.
 These paragraphs are considered a 'sub-list'.
 Using SetIndentLevel(TextRange, Int32) it is therefore possible to create multi-level lists.
 Note that sub-lists can have their own sub-sub-lists.
 The nesting level is only limited by the maximum indent level.
FormattedText will keep lists consistent.
 That means that numbered paragraphs will automatically get sequential numbers or letters.
 It also means that if the list type of one paragraphs in the list
 is changed then that change is propagated to all the paragraphs in that list.
 Even if those paragraphs were not in the input text range.
 Note that this will not affect the list type of any nested sub-lists.
Use a vertical tab character ('\v') to insert a line without a bullet or number.
 Since this does not end the paragraph this will allow the list to continue to the next paragraph.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - This text range is empty.
 -or-
 This start index of this text range is not within the text range identifying the entire text.
 -or-
 The end of this text range is not within the text range identifying the entire text.
 -or-
 This list type is not valid to set on a paragraph.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

