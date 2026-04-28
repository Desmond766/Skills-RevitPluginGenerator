---
kind: method
id: M:Autodesk.Revit.DB.TextNote.GetFormattedText
zh: 注释、文字注释
source: html/a1e3b2d7-0d56-55f9-6b30-1c5269dc39e0.htm
---
# Autodesk.Revit.DB.TextNote.GetFormattedText Method

**中文**: 注释、文字注释

Returns an object that contains text and associated formatting of this note.

## Syntax (C#)
```csharp
public FormattedText GetFormattedText()
```

## Returns
The object that contains the text and associated formatting of of the text in this text note.

## Remarks
The returned object is not attached to the text note and modifying it will not modify the contents of the text note.
 After changes are made to the FormattedText, use SetFormattedText(FormattedText) 
 apply those changes to the TextNote.

