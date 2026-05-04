---
kind: type
id: T:Autodesk.Revit.DB.PlanarFace
source: html/e5f08848-bd35-4b17-ac7b-ae39fd817d6d.htm
---
# Autodesk.Revit.DB.PlanarFace

A bounded face of a 3d solid or open shell.

## Syntax (C#)
```csharp
public class PlanarFace : Face
```

## Remarks
Planar faces are defined by planes bounded by edge loops.
The planes provide natural UV parameterization to the faces.
S(u, v) = Origin + u*Vector[0] + v*Vector[1]

