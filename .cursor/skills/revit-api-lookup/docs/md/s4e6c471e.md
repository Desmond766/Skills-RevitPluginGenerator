---
kind: method
id: M:Autodesk.Revit.DB.Element.DeleteSubelement(Autodesk.Revit.DB.Subelement)
zh: 构件、图元、元素
source: html/de199938-feea-7437-c19f-162714b70dcd.htm
---
# Autodesk.Revit.DB.Element.DeleteSubelement Method

**中文**: 构件、图元、元素

Removes a subelement from the element.

## Syntax (C#)
```csharp
public bool DeleteSubelement(
	Subelement subelem
)
```

## Parameters
- **subelem** (`Autodesk.Revit.DB.Subelement`) - The subelement to delete.

## Returns
True if entire element was deleted, false otherwise.

## Remarks
Depending on implementation for given element as the result, the element
 can be deleted - especially if after subelement deletion there are no subelements left.
 See also: IsModifiable .

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The subelement subelem does not exist in the element.
 -or-
 Subelement subelem cannot be deleted.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - This Element is an internal element, such as a component of a
 loaded family or a group type.
 -or-
 The document containing this Element is in Group Edit Mode,
 Sketch Edit Mode, or Paste Mode, and the element is not a
 member of the group, sketch, or clipboard.
 -or-
 This Element is a member of a group or sketch, and the document
 is not currently editing the group or sketch.

