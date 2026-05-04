---
kind: property
id: P:Autodesk.Revit.DB.PlanarFace.YVector
source: html/4c0891de-f7aa-9fc3-d002-55824ee412d6.htm
---
# Autodesk.Revit.DB.PlanarFace.YVector Property

The Y-vector of the planar face.

## Syntax (C#)
```csharp
public XYZ YVector { get; }
```

## Remarks
Note that the cross product of X-vector and Y-vector may result in the reverse of the FaceNormal vector
depending upon how Revit has structured this particular face.

