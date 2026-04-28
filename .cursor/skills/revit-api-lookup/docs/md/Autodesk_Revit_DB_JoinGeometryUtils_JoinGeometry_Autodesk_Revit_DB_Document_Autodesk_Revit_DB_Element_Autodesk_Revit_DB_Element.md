---
kind: method
id: M:Autodesk.Revit.DB.JoinGeometryUtils.JoinGeometry(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.Element,Autodesk.Revit.DB.Element)
zh: 连接、合并
source: html/2f223fde-0e7c-fce5-e68f-3c1ca6a6b6c1.htm
---
# Autodesk.Revit.DB.JoinGeometryUtils.JoinGeometry Method

**中文**: 连接、合并

Creates clean joins between two elements that share a common face.

## Syntax (C#)
```csharp
public static void JoinGeometry(
	Document document,
	Element firstElement,
	Element secondElement
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document containing the two elements.
- **firstElement** (`Autodesk.Revit.DB.Element`) - The first element to be joined.
- **secondElement** (`Autodesk.Revit.DB.Element`) - The second element to be joined. This element must not be joined to the first element.

## Remarks
The visible edge between joined elements is removed. The joined elements then share the same line weight and fill pattern.
 This functionality is not available for family documents.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - document is not a project document.
 -or-
 The element firstElement was not found in the given document.
 -or-
 The element secondElement was not found in the given document.
 -or-
 The elements are already joined.
 -or-
 The elements cannot be joined.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Please remove or add segments on curtain grids instead of joining or unjoining geometry of the panels.

