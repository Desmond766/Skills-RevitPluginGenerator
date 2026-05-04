---
kind: property
id: P:Autodesk.Revit.DB.PlanarFace.FaceNormal
source: html/5ddd3db6-5b9a-afda-d96e-6a607c3bcc87.htm
---
# Autodesk.Revit.DB.PlanarFace.FaceNormal Property

Normal of the planar face.

## Syntax (C#)
```csharp
public XYZ FaceNormal { get; }
```

## Remarks
This property is the "face normal" vector, and thus should return a vector consistently pointing out of
the solid that this face is a boundary for (if it is a part of a solid).

