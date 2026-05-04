---
kind: method
id: M:Autodesk.Revit.DB.DirectContext3D.IndexStreamLine.AddLine(Autodesk.Revit.DB.DirectContext3D.IndexLine)
source: html/b1d69a17-78c5-2b8f-7cdb-ad767ce81591.htm
---
# Autodesk.Revit.DB.DirectContext3D.IndexStreamLine.AddLine Method

Inserts a IndexLine segment into the stream and associated buffer.

## Syntax (C#)
```csharp
public void AddLine(
	IndexLine line
)
```

## Parameters
- **line** (`Autodesk.Revit.DB.DirectContext3D.IndexLine`) - The line segment to be inserted.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown if the associated buffer is not mapped.
 -or-
 Thrown if the associated buffer has insufficient space.

