---
kind: type
id: T:Autodesk.Revit.DB.PointOnEdge
source: html/bfd3b8e2-68d5-18e7-43e8-31798e962f10.htm
---
# Autodesk.Revit.DB.PointOnEdge

Define a ReferencePoint relative to a referenceable edge or
curve on another element.

## Syntax (C#)
```csharp
public class PointOnEdge : PointElementReference
```

## Remarks
The ReferencePoint's X basis vector is constrained to the 
tangent vector to the curve. The Y and Z vectors are free to rotate
around the curve.

