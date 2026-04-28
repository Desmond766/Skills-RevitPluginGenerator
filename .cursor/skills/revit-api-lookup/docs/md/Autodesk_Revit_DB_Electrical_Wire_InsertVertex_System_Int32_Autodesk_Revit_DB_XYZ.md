---
kind: method
id: M:Autodesk.Revit.DB.Electrical.Wire.InsertVertex(System.Int32,Autodesk.Revit.DB.XYZ)
source: html/998dbada-2ac1-72e7-c7b7-603492e83642.htm
---
# Autodesk.Revit.DB.Electrical.Wire.InsertVertex Method

Inserts a new vertex before the specified index.

## Syntax (C#)
```csharp
public void InsertVertex(
	int index,
	XYZ vertexPoint
)
```

## Parameters
- **index** (`System.Int32`) - The index of the vertex to come after this new vertex. Should be between 0 and NumberOfVertices .
- **vertexPoint** (`Autodesk.Revit.DB.XYZ`) - The point of the new vertex.

## Remarks
To add a new vertex to the end of the wire, use AppendVertex(XYZ) .

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The index should be between 0 and the number of vertices of the wire.
 -or-
 The vertex point cannot be added to the wire because there is already a vertex at this position on the view plane (within tolerance).
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.DisabledDisciplineException** - None of the following disciplines is enabled: Mechanical Electrical Piping.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Can't insert the vertex before the start vertex if the start point connects to one element.

