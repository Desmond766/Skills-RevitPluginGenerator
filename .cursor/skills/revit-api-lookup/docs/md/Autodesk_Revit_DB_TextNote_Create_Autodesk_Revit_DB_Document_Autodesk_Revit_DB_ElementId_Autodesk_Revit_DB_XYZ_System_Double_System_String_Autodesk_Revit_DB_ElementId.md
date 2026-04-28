---
kind: method
id: M:Autodesk.Revit.DB.TextNote.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.XYZ,System.Double,System.String,Autodesk.Revit.DB.ElementId)
zh: 创建、新建、生成、建立、新增
source: html/32cc6ed4-5eda-ca8b-d1df-96e667ad7bcd.htm
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
	ElementId typeId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - A valid Revit document that is currently modifiable (i.e. with an open transaction).
- **viewId** (`Autodesk.Revit.DB.ElementId`) - Id of the graphic view in which the note is to be created.
- **position** (`Autodesk.Revit.DB.XYZ`) - A model position of the new note.
 For a left-aligned text (default), the origin is set at the top-left corner of the note's bounding box.
- **width** (`System.Double`) - Width [ft] of the text in paper space (i.e. as it is measured when printed.)
 If a line of text is longer than the specified Width, the text will be automatically wrapped.
 If a a zero Width is supplied then this method will create an unwrapped text note element.
- **text** (`System.String`) - Text to populate the text note with.
- **typeId** (`Autodesk.Revit.DB.ElementId`) - Id of the text type to use for the new text note.
 The text type allows its font name parameter to be set to a font unavailable on the current system.
 However, any text note created with or set to this font type will be displayed in a default substituted font (e.g. Arial)
 and the UI will show a blank value in the text type font name parameter.
 Once the document is opened on a system which has the font set on the text type,
 the text note will display with that font and the UI will show that font in the text type font name parameter.

## Returns
The newly created text note.

## Remarks
As a view-specific element the text note will be visible only in the specified view. The new text note will be created using the given text type, which defines the style.
 The currently default style can be obtained from the Document.GetDefaultElementTypeId method.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The document is a family that cannot contain text notes.
 -or-
 The viewId does not represent a valid graphic view element in the given document.
 -or-
 The typeId does not represent a valid text type in the given document.
 -or-
 A valid point must not be father then 10 miles (approx. 16 km) from the origin.
 -or-
 The given width is not valid. A valid value must be within the range
 returned by the static methods GetMinimumAllowedWidth and GetMaximumAllowedWidth.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

