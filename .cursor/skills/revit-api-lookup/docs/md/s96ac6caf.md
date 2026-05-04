---
kind: property
id: P:Autodesk.Revit.DB.PlanarFace.XVector
source: html/05128277-2f8d-79ad-0e93-8a1842fcc2a4.htm
---
# Autodesk.Revit.DB.PlanarFace.XVector Property

The X-vector of the planar face.

## Syntax (C#)
```csharp
public XYZ XVector { get; }
```

## Remarks
Note that the cross product of X-vector and Y-vector may result in the reverse of the FaceNormal vector
depending upon how Revit has structured this particular face.

