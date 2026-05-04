---
kind: method
id: M:Autodesk.Revit.DB.DirectContext3D.VertexStreamPosition.AddVertex(Autodesk.Revit.DB.DirectContext3D.VertexPosition)
source: html/bec47574-5078-23b7-b5c8-0998c97f8471.htm
---
# Autodesk.Revit.DB.DirectContext3D.VertexStreamPosition.AddVertex Method

Inserts a VertexStreamPosition into the stream and associated buffer.

## Syntax (C#)
```csharp
public void AddVertex(
	VertexPosition vertex
)
```

## Parameters
- **vertex** (`Autodesk.Revit.DB.DirectContext3D.VertexPosition`) - The vertex to be inserted.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown if the associated buffer is not mapped.
 -or-
 Thrown if the associated buffer has insufficient space.

