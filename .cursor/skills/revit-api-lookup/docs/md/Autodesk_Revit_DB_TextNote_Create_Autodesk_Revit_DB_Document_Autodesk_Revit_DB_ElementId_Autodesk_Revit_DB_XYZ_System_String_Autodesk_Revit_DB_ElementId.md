---
kind: method
id: M:Autodesk.Revit.DB.TextNote.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.XYZ,System.String,Autodesk.Revit.DB.ElementId)
zh: 创建、新建、生成、建立、新增
source: html/465d02a9-8bc8-8e9f-cc57-642c2626e4d6.htm
---
# Autodesk.Revit.DB.TextNote.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new unwrapped TextNote element with the given properties.

## Syntax (C#)
```csharp
public static TextNote Create(
	Document document,
	ElementId viewId,
	XYZ position,
	string text,
	ElementId typeId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - A valid Revit document that is currently modifiable (i.e. with an open transaction).
- **viewId** (`Autodesk.Revit.DB.ElementId`) - Id of the graphic view in which the note is to be created.
- **position** (`Autodesk.Revit.DB.XYZ`) - A model position of the new note.
 For a left-aligned text (default), the origin is set at the top-left corner of the note's bounding box.
- **text** (`System.String`) - Text to populate the text note with.
- **typeId** (`Autodesk.Revit.DB.ElementId`) - Id of the text type to use for the new text note.

## Returns
The newly created text note.

## Remarks
The new TextNote will consist of a single line of text unless there
 are carriage return ('\r') or vertical tab ('\v') characters in the given string. Once the text note is
 created its width gets adjusted to fit the longest (or the single one) line of text. As a view-specific element the TextNote will be visible only in the specified view. The new TextNote will be created using the given text type, which defines the style.
 The currently default style can be obtained from the Document.GetDefaultElementTypeId method.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The document is a family that cannot contain text notes.
 -or-
 The viewId does not represent a valid graphic view element in the given document.
 -or-
 The typeId does not represent a valid text type in the given document.
 -or-
 A valid point must not be father then 10 miles (approx. 16 km) from the origin.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

