---
kind: method
id: M:Autodesk.Revit.DB.DirectContext3D.IndexStreamLine.AddLines(System.Collections.Generic.IList{Autodesk.Revit.DB.DirectContext3D.IndexLine})
source: html/ef1aa8e3-6971-656d-6c81-9557508f909a.htm
---
# Autodesk.Revit.DB.DirectContext3D.IndexStreamLine.AddLines Method

Inserts multiple IndexLine segments into the stream and associated buffer.

## Syntax (C#)
```csharp
public void AddLines(
	IList<IndexLine> lines
)
```

## Parameters
- **lines** (`System.Collections.Generic.IList < IndexLine >`) - The line segments to be inserted.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown if the associated buffer is not mapped.
 -or-
 Thrown if the associated buffer has insufficient space.

