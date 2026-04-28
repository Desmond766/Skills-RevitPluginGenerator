---
kind: method
id: M:Autodesk.Revit.DB.Face.IsInside(Autodesk.Revit.DB.UV)
source: html/76c639c2-ddce-f010-f81a-bd59e46cc5e1.htm
---
# Autodesk.Revit.DB.Face.IsInside Method

Indicates whether the specified point is within this face.

## Syntax (C#)
```csharp
public bool IsInside(
	UV point
)
```

## Parameters
- **point** (`Autodesk.Revit.DB.UV`) - The parameters to be evaluated, in natural parameterization of the face.

## Returns
True if point is within this face or on its boundary, otherwise false.

