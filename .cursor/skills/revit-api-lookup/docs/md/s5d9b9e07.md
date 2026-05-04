---
kind: method
id: M:Autodesk.Revit.DB.DirectContext3D.IndexStreamPoint.AddPoints(System.Collections.Generic.IList{Autodesk.Revit.DB.DirectContext3D.IndexPoint})
source: html/75375c45-cc36-dae2-f21c-e1d6a36b221e.htm
---
# Autodesk.Revit.DB.DirectContext3D.IndexStreamPoint.AddPoints Method

Inserts multiple IndexPoint instances into the stream and associated buffer.

## Syntax (C#)
```csharp
public void AddPoints(
	IList<IndexPoint> points
)
```

## Parameters
- **points** (`System.Collections.Generic.IList < IndexPoint >`) - The points to be inserted.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown if the associated buffer is not mapped.
 -or-
 Thrown if the associated buffer has insufficient space.

