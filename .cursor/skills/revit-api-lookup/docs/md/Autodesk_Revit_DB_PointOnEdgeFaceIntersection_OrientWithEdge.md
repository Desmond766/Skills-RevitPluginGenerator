---
kind: property
id: P:Autodesk.Revit.DB.PointOnEdgeFaceIntersection.OrientWithEdge
source: html/2f3c37d7-7b70-1305-33dd-96738ffb5107.htm
---
# Autodesk.Revit.DB.PointOnEdgeFaceIntersection.OrientWithEdge Property

Whether to orient the ReferencePoint to the edge or the face.

## Syntax (C#)
```csharp
public bool OrientWithEdge { get; set; }
```

## Remarks
If true, the X basis vector will be parallel to the edge.
If false, the X and Y basis vectors will be parallel to the face.

