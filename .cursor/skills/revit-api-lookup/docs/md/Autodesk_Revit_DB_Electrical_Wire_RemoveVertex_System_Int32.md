---
kind: method
id: M:Autodesk.Revit.DB.Electrical.Wire.RemoveVertex(System.Int32)
source: html/0d16213b-1098-6ca9-1e2b-70068f619ae8.htm
---
# Autodesk.Revit.DB.Electrical.Wire.RemoveVertex Method

Removes the vertex corresponding to the specified index.
 Can not remove the start or end vertex if it already connects to other element.

## Syntax (C#)
```csharp
public void RemoveVertex(
	int index
)
```

## Parameters
- **index** (`System.Int32`) - The index which should be in [0, NumberOfVertices).

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The index should be between 0 and the number of vertices of the wire.
- **Autodesk.Revit.Exceptions.DisabledDisciplineException** - None of the following disciplines is enabled: Mechanical Electrical Piping.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The wire has only 2 vertices, so one cannot be removed.
 -or-
 Can't remove the vertex when the vertex is start or end point and the wire connects to one element.

