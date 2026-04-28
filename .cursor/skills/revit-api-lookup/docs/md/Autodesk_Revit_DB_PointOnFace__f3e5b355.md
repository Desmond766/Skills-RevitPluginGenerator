---
kind: type
id: T:Autodesk.Revit.DB.PointOnFace
source: html/8a2f99dc-4905-8be7-0ddf-2bf52b438afd.htm
---
# Autodesk.Revit.DB.PointOnFace

Define a ReferencePoint relative to a Face.

## Syntax (C#)
```csharp
public class PointOnFace : PointElementReference
```

## Remarks
A ReferencePoint on a Face has its X and Y
basis vectors parallel to the Face, but is free to rotate
around its Z basis vector. It must lie on the face 
(unlike PointOnPlane).

