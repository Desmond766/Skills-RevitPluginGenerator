---
kind: type
id: T:Autodesk.Revit.DB.FormattedText
source: html/79a92343-2342-8325-1b51-f12c4fb05481.htm
---
# Autodesk.Revit.DB.FormattedText

FormattedText is used to create, edit and format text in a TextNote 
 or to query the text and format properties of a TextNode

## Syntax (C#)
```csharp
public class FormattedText : IDisposable
```

## Remarks
An instance of FormattedText can be obtained from a TextNote 
 (See TextNote.GetFormattedText() )
 or from a TextNode 
 (See TextNode.GetFormattedText() )
It is also possible to create a new instance of FormattedText and assign it
 to a TextNote 
 (See TextNote.SetFormattedText() )
 This will result in a TextNote with text with the specified formatting applied
Formatted text can be used to:
 Create formatted text for a new TextNote Edit, Find and Replace text in an existing TextNote Modify formatting of text in an existing TextNote Or query the text and formatting a TextNote or a TextNode 
 Formatted text can be populated with plain text by using its
 constructor FormattedText(String) that takes a string,
 or by using the SetPlainText(String) method.
In addition, selected ranges of text can be added, removed, or replaced with the
 SetPlainText(TextRange, String) method
 by specifying a TextRange .
Use the Find(String, Int32, Boolean, Boolean) method to find the location of existing text.
Formatted text can have up to 30,000 characters.
 All characters, except the linefeed character ('\n'), are allowed.
 This means that you should not use the 'Environment.NewLine' property, since that includes a linefeed character.
 Use the carriage return character ('\r') to terminate a paragraph.
 And use a vertical tab character ('\v') to create a new line without terminating the paragraph.
Formatted text allows for individual characters to be formatted.
 The following formatting can be applied.
 Bold Italic Underline Superscript/Subscript All Caps 
 Use SetBoldStatus(TextRange, Boolean) )
 , SetItalicStatus(TextRange, Boolean) )
 , SetUnderlineStatus(TextRange, Boolean) )
 , SetSuperscriptStatus(TextRange, Boolean) )
 , SetSubscriptStatus(TextRange, Boolean) )
 , or SetAllCapsStatus(TextRange, Boolean) )
 to set the character formatting on a range of text.
Use GetBoldStatus(TextRange) )
 , GetItalicStatus(TextRange) )
 , GetUnderlineStatus(TextRange) )
 , GetSuperscriptStatus(TextRange) )
 , GetSubscriptStatus(TextRange) )
 , or GetAllCapsStatus(TextRange) )
 to get the character formatting of a range of text.
Text can be broken up in paragraphs. Paragraphs are terminated by a carriage return character ('\r').
Each paragraph can be indented several levels deep.
 For each additional level the indentation increments by one tab size.
 The total indentation is the product of a tab size and the indent level.
 Use SetIndentLevel(TextRange, Int32) to set the level of indenting
 up to a maximum indent level that can be obtained from
 GetMaximumIndentLevel() () () () 
 Use GetIndentLevel(TextRange) to find the indent level of a given range of text.
Note that the tab size is determined by the object that will contain the FormattedText.
In the case of a TextNote the tab size is a property of the TextNoteType 
 returned from TextNote.TextNoteType .
 The tab size can be found by calling the Parameter [Guid] 
 with TEXT_TAB_SIZE on the TextNoteType obtained from the TextNote 
 In the case of a TextNode the tab size can be obtained from its TabSize property
Formatted text can also be used to create numbered or bulleted paragraphs with the
 SetListType(TextRange, ListType) method.
The following ListType options are available:
 Bullet ArabicNumbers LowerCaseLetters UpperCaseLetters 
 Paragraphs with a ListType other than None are considered
 to be 'list' paragraphs.
 Consecutive list paragraphs with the same indentation level are treated as part of the same list.
 A list ends when a list paragraph is followed by
 a paragraph that has None or a list paragraph that has a lower indentation level, i.e. is indented less.
 (See GetIndentLevel(TextRange) ) 
 Note that a list will continue uninterrupted after list paragraphs that have higher indentation level.
 These paragraphs form a 'sub-list' of the list they interrupt.
 Sub-lists can have their own sub-sub-lists.
 The nesting level is only limited by the maximum indent level.
 Using SetIndentLevel(TextRange, Int32) it is therefore possible to create multi-level lists.
FormattedText will keep lists consistent.
 That means that list paragraphs will automatically get sequential numbers or letters.
 It also means that if the list type of one of the paragraphs in a list
 is changed then that change is propagated to all the paragraphs in that list.
 Note that this will not affect the list type of any nested sub-lists.
Use a vertical tab character ('\v') to insert a line without a bullet or number.
 Since this does not end the paragraph this will allow the list to continue to the next paragraph.

