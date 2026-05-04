---
kind: method
id: M:Autodesk.Revit.DB.BRepBuilder.IsValidFaceId(Autodesk.Revit.DB.BRepBuilderGeometryId)
source: html/476756cc-99d9-b891-9583-3fe7dff48c75.htm
---
# Autodesk.Revit.DB.BRepBuilder.IsValidFaceId Method

A validator function that checks whether the face id corresponds to a face previously added to this BRepBuilder object.

## Syntax (C#)
```csharp
public bool IsValidFaceId(
	BRepBuilderGeometryId faceId
)
```

## Parameters
- **faceId** (`Autodesk.Revit.DB.BRepBuilderGeometryId`) - Face id to be validated.

## Returns
True if faceId corresponds to a face previously added to this BRepBuilder, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

