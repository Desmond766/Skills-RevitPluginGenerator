---
kind: method
id: M:Autodesk.Revit.DB.DirectContext3D.VertexStreamPositionColored.AddVertex(Autodesk.Revit.DB.DirectContext3D.VertexPositionColored)
source: html/10b44d88-f3d6-5180-66ee-cef78fc07582.htm
---
# Autodesk.Revit.DB.DirectContext3D.VertexStreamPositionColored.AddVertex Method

Inserts a VertexStreamPositionColored into the stream and associated buffer.

## Syntax (C#)
```csharp
public void AddVertex(
	VertexPositionColored vertex
)
```

## Parameters
- **vertex** (`Autodesk.Revit.DB.DirectContext3D.VertexPositionColored`) - The vertex to be inserted.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown if the associated buffer is not mapped.
 -or-
 Thrown if the associated buffer has insufficient space.

