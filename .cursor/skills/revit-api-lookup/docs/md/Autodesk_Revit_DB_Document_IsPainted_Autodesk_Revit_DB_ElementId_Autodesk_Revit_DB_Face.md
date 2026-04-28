---
kind: method
id: M:Autodesk.Revit.DB.Document.IsPainted(Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.Face)
zh: 文档、文件
source: html/638f398e-bb20-53c4-55a6-454d8a0a1029.htm
---
# Autodesk.Revit.DB.Document.IsPainted Method

**中文**: 文档、文件

Checks if the element's face is painted with a material.

## Syntax (C#)
```csharp
public bool IsPainted(
	ElementId elementId,
	Face face
)
```

## Parameters
- **elementId** (`Autodesk.Revit.DB.ElementId`) - The element that the face belongs to.
- **face** (`Autodesk.Revit.DB.Face`) - The painted element's face.

## Returns
True if the element's face is painted.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The element elementId does not exist in the document
 -or-
 The face doesn't belong to the element
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

