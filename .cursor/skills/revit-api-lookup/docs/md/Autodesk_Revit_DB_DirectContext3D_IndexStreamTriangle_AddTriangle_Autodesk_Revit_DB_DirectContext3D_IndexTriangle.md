---
kind: method
id: M:Autodesk.Revit.DB.DirectContext3D.IndexStreamTriangle.AddTriangle(Autodesk.Revit.DB.DirectContext3D.IndexTriangle)
source: html/59ae57c9-3b92-182d-74c6-7f1ac2ec1cb9.htm
---
# Autodesk.Revit.DB.DirectContext3D.IndexStreamTriangle.AddTriangle Method

Inserts a IndexTriangle into the stream and associated buffer.

## Syntax (C#)
```csharp
public void AddTriangle(
	IndexTriangle triangle
)
```

## Parameters
- **triangle** (`Autodesk.Revit.DB.DirectContext3D.IndexTriangle`) - The triangle to be inserted.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown if the associated buffer is not mapped.
 -or-
 Thrown if the associated buffer has insufficient space.

