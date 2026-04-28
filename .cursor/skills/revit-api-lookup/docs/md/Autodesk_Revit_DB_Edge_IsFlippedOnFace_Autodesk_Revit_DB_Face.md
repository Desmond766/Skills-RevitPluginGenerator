---
kind: method
id: M:Autodesk.Revit.DB.Edge.IsFlippedOnFace(Autodesk.Revit.DB.Face)
source: html/1b7bfbea-9f67-ef97-9469-98cd063c33a8.htm
---
# Autodesk.Revit.DB.Edge.IsFlippedOnFace Method

Determines if this edge's topological direction on the Face is opposite to its parametric direction.

## Syntax (C#)
```csharp
public bool IsFlippedOnFace(
	Face face
)
```

## Parameters
- **face** (`Autodesk.Revit.DB.Face`) - The face with respect to which the direction is considered. Must belong to the edge.

## Returns
true if this edge's topological direction on the Face is opposite to its parametric direction, false if the topological direction agrees with the parametric direction.

## Remarks
Outer edge loops on a Face are oriented counter-clockwise with respect to the Face's orientation, 
and inner loops are oriented clockwise. The topological direction of an edge on a face means the direction 
in which the edge's loop is being traversed.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when the specified face is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the specified face is not one of the faces for this edge.

