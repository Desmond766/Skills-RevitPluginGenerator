---
kind: method
id: M:Autodesk.Revit.DB.Document.RemovePaint(Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.Face)
zh: 文档、文件
source: html/7ba7c440-7ed5-c3ff-9b9e-4413bf22a0c4.htm
---
# Autodesk.Revit.DB.Document.RemovePaint Method

**中文**: 文档、文件

Remove the material painted on the element's face.
 If the face is currently not painted,it will do nothing.

## Syntax (C#)
```csharp
public void RemovePaint(
	ElementId elementId,
	Face face
)
```

## Parameters
- **elementId** (`Autodesk.Revit.DB.ElementId`) - The element that the painted face belongs to.
- **face** (`Autodesk.Revit.DB.Face`) - The painted element's face.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The element elementId does not exist in the document
 -or-
 The face doesn't belong to the element
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

