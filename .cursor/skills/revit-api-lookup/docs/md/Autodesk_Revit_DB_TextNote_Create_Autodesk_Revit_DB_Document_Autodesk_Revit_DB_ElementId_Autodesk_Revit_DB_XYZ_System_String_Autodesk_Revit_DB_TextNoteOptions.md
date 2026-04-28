---
kind: method
id: M:Autodesk.Revit.DB.TextNote.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.XYZ,System.String,Autodesk.Revit.DB.TextNoteOptions)
zh: 创建、新建、生成、建立、新增
source: html/b5e7dc0d-3b46-6747-dfe0-83c93b2057a2.htm
---
# Autodesk.Revit.DB.TextNote.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new unwrapped text note element with the given properties.

## Syntax (C#)
```csharp
public static TextNote Create(
	Document document,
	ElementId viewId,
	XYZ position,
	string text,
	TextNoteOptions options
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - A valid Revit document that is currently modifiable (i.e. with an open transaction).
- **viewId** (`Autodesk.Revit.DB.ElementId`) - Id of the graphic view in which the note is to be created.
- **position** (`Autodesk.Revit.DB.XYZ`) - A model position of the new note.
 Note that the position's relation to the text's bounding box depends on the requested text alignment
 (set via the Options argument). It will be the box' top-left corner for a left-aligned text,
 the top-right corner for a right-aligned text, and middle-top point if the text is to be centered.
- **text** (`System.String`) - Text to populate the text note with.
- **options** (`Autodesk.Revit.DB.TextNoteOptions`) - Options to control behavior and appearance of the text note.

## Returns
The newly created text note.

## Remarks
The new text note will consist of a single line of text unless there
 are line-break characters (CR) in the given string. Once the text note is
 created its width gets adjusted to fit the longest (or the single one) line of text.
As a view-specific element the text note will be visible only in the specified view.
The new text note will be created using the given text type, which defines the style.
 The currently default style can be obtained from the Document.GetDefaultElementTypeId method.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The document is a family that cannot contain text notes.
 -or-
 The viewId does not represent a valid graphic view element in the given document.
 -or-
 The options structure does not contain a valid text type to use for a new text note in the given document.
 -or-
 A valid point must not be father then 10 miles (approx. 16 km) from the origin.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

