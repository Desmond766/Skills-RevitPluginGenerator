---
kind: method
id: M:Autodesk.Revit.DB.Face.Evaluate(Autodesk.Revit.DB.UV)
source: html/d1219dd7-fc7a-6b12-afce-963d554e947d.htm
---
# Autodesk.Revit.DB.Face.Evaluate Method

Evaluates and returns the XYZ coordinates of a point at the indicated UV parameterization of the face.

## Syntax (C#)
```csharp
public XYZ Evaluate(
	UV params
)
```

## Parameters
- **params** (`Autodesk.Revit.DB.UV`) - The parameters to be evaluated, in natural parameterization of the face.

## Returns
The XYZ coordinates.

## Remarks
The evaluation is performed on the underlying Surface, and can return results outside of the boundaries of the face.

