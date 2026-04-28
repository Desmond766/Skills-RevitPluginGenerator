---
kind: method
id: M:Autodesk.Revit.DB.DirectContext3D.IndexStreamPoint.AddPoint(Autodesk.Revit.DB.DirectContext3D.IndexPoint)
source: html/4d245a54-7ead-f032-eefd-8cf0e8c4dfe4.htm
---
# Autodesk.Revit.DB.DirectContext3D.IndexStreamPoint.AddPoint Method

Inserts a IndexPoint into the stream and associated buffer.

## Syntax (C#)
```csharp
public void AddPoint(
	IndexPoint point
)
```

## Parameters
- **point** (`Autodesk.Revit.DB.DirectContext3D.IndexPoint`) - The point to be inserted.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown if the associated buffer is not mapped.
 -or-
 Thrown if the associated buffer has insufficient space.

