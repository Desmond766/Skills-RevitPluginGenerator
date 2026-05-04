---
kind: method
id: M:Autodesk.Revit.DB.ElementTransformUtils.CopyElements(Autodesk.Revit.DB.Document,System.Collections.Generic.ICollection{Autodesk.Revit.DB.ElementId},Autodesk.Revit.DB.XYZ)
zh: 复制
source: html/0e533605-477f-dd92-2376-15ff7cd4411c.htm
---
# Autodesk.Revit.DB.ElementTransformUtils.CopyElements Method

**中文**: 复制

Copies a set of elements and places the copies at a location indicated by a given translation.

## Syntax (C#)
```csharp
public static ICollection<ElementId> CopyElements(
	Document document,
	ICollection<ElementId> elementsToCopy,
	XYZ translation
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document that owns the elements.
- **elementsToCopy** (`System.Collections.Generic.ICollection < ElementId >`) - The set of elements to copy.
- **translation** (`Autodesk.Revit.DB.XYZ`) - The translation vector for the new elements.

## Returns
The ids of the newly created copied elements.

## Remarks
This method is not suitable for elements that are hosted in other elements as it does not perform rehosting. If you need to rehost your elements in addition
 to copying them, use one of the other CopyElements() overloads.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given element id set is empty.
 -or-
 One or more elements in elementsToCopy do not exist in the document.
 -or-
 Some of the elements cannot be copied, because they belong to different views.
 -or-
 The input set of elements contains Sketch members along with other elements or there is no active Sketch edit mode.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - It is not allowed to copy Sketch members between non-parallel sketches.
 -or-
 If we are not able to copy all the elements.

