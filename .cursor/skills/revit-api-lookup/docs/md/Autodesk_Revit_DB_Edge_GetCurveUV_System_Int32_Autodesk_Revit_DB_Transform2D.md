---
kind: method
id: M:Autodesk.Revit.DB.Edge.GetCurveUV(System.Int32,Autodesk.Revit.DB.Transform2D)
source: html/ce3b5773-846f-9ad4-6316-ebbfeadde0bb.htm
---
# Autodesk.Revit.DB.Edge.GetCurveUV Method

Calculate and transform a 2D curve that represents the edge in the uv-parameter plane of one of the edge's faces.
The output curve's direction will follow the parametric direction of the edge, not the topological
direction of the edge on the given face.

## Syntax (C#)
```csharp
public CurveUV GetCurveUV(
	int index,
	Transform2D transform
)
```

## Parameters
- **index** (`System.Int32`) - The index of the face (0 or 1).
- **transform** (`Autodesk.Revit.DB.Transform2D`) - Transformation to apply to the curve.

## Returns
If successful, returns the calculated and transformed CurveUV, Nothing nullptr a null reference ( Nothing in Visual Basic) otherwise.

## Remarks
Use of this function is preferred over using GetCurveUV(int index) and then transforming the curve, as the latter approach may yield a less accurate result.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - Thrown when the specified index is not 0 or 1.

