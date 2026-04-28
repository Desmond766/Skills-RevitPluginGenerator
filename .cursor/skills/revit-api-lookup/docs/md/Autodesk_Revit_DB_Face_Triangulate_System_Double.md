---
kind: method
id: M:Autodesk.Revit.DB.Face.Triangulate(System.Double)
source: html/b571177c-1268-35cd-0be1-e19db29fcb20.htm
---
# Autodesk.Revit.DB.Face.Triangulate Method

Returns a triangular mesh approximation to the face.

## Syntax (C#)
```csharp
public Mesh Triangulate(
	double levelOfDetail
)
```

## Parameters
- **levelOfDetail** (`System.Double`) - The level of detail. Its range is from 0 to 1. 0 is the lowest level of detail and 1 is the highest.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - Thrown when level of detail is less than 0 or greater than 1.

