---
kind: type
id: T:Autodesk.Revit.DB.PointOnEdgeEdgeIntersection
source: html/858ddd4d-3e40-2faa-ee40-553399d29005.htm
---
# Autodesk.Revit.DB.PointOnEdgeEdgeIntersection

Define a ReferencePoint at the intersection of two
referenceable lines.

## Syntax (C#)
```csharp
public class PointOnEdgeEdgeIntersection : PointElementReference
```

## Remarks
The ReferencePoint is actually placed on the first
line (Edge1) at the closest point to the second line (Edge2).
Its X basis vector is constrained to be parallel to the first
line.

