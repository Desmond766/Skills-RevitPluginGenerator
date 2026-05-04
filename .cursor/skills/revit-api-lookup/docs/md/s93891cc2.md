---
kind: method
id: M:Autodesk.Revit.DB.TextNote.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.XYZ,System.Double,System.String,Autodesk.Revit.DB.TextNoteOptions)
zh: 创建、新建、生成、建立、新增
source: html/f97214ec-08fc-0ff8-7bc8-047231501523.htm
---
# Autodesk.Revit.DB.TextNote.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new line-wrapping text note element of the given width and properties.

## Syntax (C#)
```csharp
public static TextNote Create(
	Document document,
	ElementId viewId,
	XYZ position,
	double width,
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
- **width** (`System.Double`) - Width [ft] of the text in paper space (i.e. as it is measured when printed.)
 If a line of text is longer than the given specified Width, the text will be automatically wrapped.
 If a a zero Width is supplied then this method will create an unwrapped text note element.
- **text** (`System.String`) - Text to populate the text note with.
- **options** (`Autodesk.Revit.DB.TextNoteOptions`) - Options to control behavior and appearance of the text note.

## Returns
The newly created text note.

## Remarks
As a view-specific element the text note will be visible only in the specified view. The new text note will be created using the give text type, which defines the style.
 The currently default style can be obtained from the Document.GetDefaultElementTypeId method.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The document is a family that cannot contain text notes.
 -or-
 The viewId does not represent a valid graphic view element in the given document.
 -or-
 The options structure does not contain a valid text type to use for a new text note in the given document.
 -or-
 A valid point must not be father then 10 miles (approx. 16 km) from the origin.
 -or-
 The given width is not valid. A valid value must be within the range
 returned by static methods GetMinimumWidthLimit and GetMaximumWidthLimit.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

