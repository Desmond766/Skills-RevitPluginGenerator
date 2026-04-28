---
kind: method
id: M:Autodesk.Revit.DB.Element.DeleteSubelements(System.Collections.Generic.IList{Autodesk.Revit.DB.Subelement})
zh: 构件、图元、元素
source: html/6410b135-88fe-b111-769f-f14e86b42a05.htm
---
# Autodesk.Revit.DB.Element.DeleteSubelements Method

**中文**: 构件、图元、元素

Removes the subelements from the element.

## Syntax (C#)
```csharp
public bool DeleteSubelements(
	IList<Subelement> subelems
)
```

## Parameters
- **subelems** (`System.Collections.Generic.IList < Subelement >`) - Subelements to delete.

## Returns
True if entire element was deleted, false otherwise.

## Remarks
Depending on implementation for given element as the result, the element
 can be deleted - especially if after Subelement deletion there are no Subelement left.
 See also: IsModifiable .

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - One or more subelements in subelems do not exist in the element.
 -or-
 One or more of the subelements subelems cannot be deleted.
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

