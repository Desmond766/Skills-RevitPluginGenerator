---
kind: method
id: M:Autodesk.Revit.DB.ElementTransformUtils.MirrorElements(Autodesk.Revit.DB.Document,System.Collections.Generic.ICollection{Autodesk.Revit.DB.ElementId},Autodesk.Revit.DB.Plane,System.Boolean)
zh: 镜像
source: html/bb533c52-171a-85f9-8896-c7bb661e129f.htm
---
# Autodesk.Revit.DB.ElementTransformUtils.MirrorElements Method

**中文**: 镜像

Mirrors a set of elements about a given plane.

## Syntax (C#)
```csharp
public static IList<ElementId> MirrorElements(
	Document document,
	ICollection<ElementId> elementsToMirror,
	Plane plane,
	bool mirrorCopies
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document that owns the elements.
- **elementsToMirror** (`System.Collections.Generic.ICollection < ElementId >`) - The set of elements to mirror.
- **plane** (`Autodesk.Revit.DB.Plane`) - The mirror plane.
- **mirrorCopies** (`System.Boolean`) - True if mirroring should be performed on copies of the elements, leaving the original elements intact.
 False if no copies should be created and the elements should be mirrored directly.

## Returns
A collection of ids of newly created elements - mirrored copies. It is empty if the mirrorCopies arguments is false.

## Remarks
Optionally, copies of the elements can be created prior to the operation and mirroring is then performed on the copies instead of the original elements.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - elementsToMirror cannot be mirrored.
 -or-
 The given element id set is empty.
 -or-
 One or more elements in elementsToMirror do not exist in the document.
 -or-
 Some of the elements cannot be copied, because they belong to different views.
 -or-
 The input set of elements contains Sketch members along with other elements or there is no active Sketch edit mode.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the elements cannot be moved (e.g. due to some of the elements being pinned).

