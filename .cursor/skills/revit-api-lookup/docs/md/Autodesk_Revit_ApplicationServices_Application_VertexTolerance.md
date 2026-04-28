---
kind: property
id: P:Autodesk.Revit.ApplicationServices.Application.VertexTolerance
source: html/5e064096-daf4-0fcf-65ff-bf058c5b67f5.htm
---
# Autodesk.Revit.ApplicationServices.Application.VertexTolerance Property

Vertex tolerance.

## Syntax (C#)
```csharp
public double VertexTolerance { get; }
```

## Remarks
Two points within this distance are considered coincident.
 Do not use this value for any purpose other than its intended purpose,
 which is to check if two points are the same within this tolerance value.
 Do not use this value to set the distance between two points.
 Doing so will result in unstable behavior.

