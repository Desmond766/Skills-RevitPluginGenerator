---
kind: method
id: M:Autodesk.Revit.DB.ElementTransformUtils.MirrorElement(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.Plane)
zh: 镜像
source: html/36027166-d494-9937-74c2-d61197af3878.htm
---
# Autodesk.Revit.DB.ElementTransformUtils.MirrorElement Method

**中文**: 镜像

Creates a mirrored copy of an element about a given plane.

## Syntax (C#)
```csharp
public static void MirrorElement(
	Document document,
	ElementId elementToMirror,
	Plane plane
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document that owns the element.
- **elementToMirror** (`Autodesk.Revit.DB.ElementId`) - The element to mirror.
- **plane** (`Autodesk.Revit.DB.Plane`) - The mirror plane.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - elementToMirror cannot be mirrored.
 -or-
 The element elementToMirror does not exist in the document
 -or-
 The input element is a Sketch member and there is no Sketch in the edit mode to place this element in.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

