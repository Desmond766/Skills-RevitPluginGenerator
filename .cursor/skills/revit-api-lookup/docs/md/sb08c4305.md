---
kind: method
id: M:Autodesk.Revit.DB.Edge.IsFlippedOnFace(System.Int32)
source: html/779513a0-db59-8b53-a53b-f3cc10e6ddf0.htm
---
# Autodesk.Revit.DB.Edge.IsFlippedOnFace Method

Determines if this edge's topological direction on the Face is opposite to its parametric direction.

## Syntax (C#)
```csharp
public bool IsFlippedOnFace(
	int index
)
```

## Parameters
- **index** (`System.Int32`) - The index of the face (0 or 1).

## Returns
true if this edge's topological direction on the Face is opposite to its parametric direction, false if the topological direction agrees with the parametric direction.

## Remarks
Outer edge loops on a Face are oriented counter-clockwise with respect to the Face's orientation, 
and inner loops are oriented clockwise. The topological direction of an edge on a face means the direction 
in which the edge's loop is being traversed.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - Thrown when the specified index is not 0 or 1.

