---
kind: method
id: M:Autodesk.Revit.DB.SlabShapeEditor.AddPoints(System.Collections.Generic.IList{Autodesk.Revit.DB.XYZ})
source: html/52f630ac-2e57-4b33-7776-d499d469630d.htm
---
# Autodesk.Revit.DB.SlabShapeEditor.AddPoints Method

Add an array of points to the element.

## Syntax (C#)
```csharp
public IList<SlabShapeVertex> AddPoints(
	IList<XYZ> points
)
```

## Parameters
- **points** (`System.Collections.Generic.IList < XYZ >`) - The point array.

## Returns
The newly added slab shape vertices.

## Remarks
The newly added points should be distinct on the x-y plane, and they should be inside the element boundary.
 SlabShapeEditor must be enabled before calling this method.
 Regenerate the document after element creation if this method is called in the same transaction.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The input points are not valid. Please check if they are distinct on the x-y plane.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

