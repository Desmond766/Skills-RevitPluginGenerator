---
kind: method
id: M:Autodesk.Revit.DB.Edge.GetCurveUV(System.Int32)
source: html/e06c6807-14e7-3b6f-976f-8b78eab42081.htm
---
# Autodesk.Revit.DB.Edge.GetCurveUV Method

Calculate a 2D curve that represents the edge in the uv-parameter plane of one of the edge's faces.
The output curve's direction will follow the parametric direction of the edge, not the topological
direction of the edge on the given face.

## Syntax (C#)
```csharp
public CurveUV GetCurveUV(
	int index
)
```

## Parameters
- **index** (`System.Int32`) - The index of the face (0 or 1).

## Returns
If successful, returns the calculated CurveUV, Nothing nullptr a null reference ( Nothing in Visual Basic) otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - Thrown when the specified index is not 0 or 1.

