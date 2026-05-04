---
kind: property
id: P:Autodesk.Revit.DB.Edge.ApproximateLength
source: html/e9cc0551-27c5-82de-d620-cd628ee6eb2b.htm
---
# Autodesk.Revit.DB.Edge.ApproximateLength Property

Returns the approximate length of the edge.

## Syntax (C#)
```csharp
public double ApproximateLength { get; }
```

## Remarks
Estimates the length of the edge by adding together tessellated segments, 
Will underestimate when the surface is curved.

