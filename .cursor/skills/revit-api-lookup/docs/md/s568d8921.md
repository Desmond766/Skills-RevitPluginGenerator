---
kind: method
id: M:Autodesk.Revit.DB.Document.GetPaintedMaterial(Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.Face)
zh: 文档、文件
source: html/6f40681b-18ba-6d8d-b00f-9f3922466a37.htm
---
# Autodesk.Revit.DB.Document.GetPaintedMaterial Method

**中文**: 文档、文件

Get the material painted on the element's face. Returns invalidElementId if the face is not painted.

## Syntax (C#)
```csharp
public ElementId GetPaintedMaterial(
	ElementId elementId,
	Face face
)
```

## Parameters
- **elementId** (`Autodesk.Revit.DB.ElementId`) - The element that the face belongs to.
- **face** (`Autodesk.Revit.DB.Face`) - The painted element's face.

## Returns
The material's Id painted on the element's face.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The element elementId does not exist in the document
 -or-
 The face doesn't belong to the element
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

