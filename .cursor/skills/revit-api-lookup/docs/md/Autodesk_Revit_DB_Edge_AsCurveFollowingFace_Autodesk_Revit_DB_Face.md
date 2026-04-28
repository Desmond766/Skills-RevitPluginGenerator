---
kind: method
id: M:Autodesk.Revit.DB.Edge.AsCurveFollowingFace(Autodesk.Revit.DB.Face)
source: html/5f534a16-8e48-f667-1fe6-2a58f11118ed.htm
---
# Autodesk.Revit.DB.Edge.AsCurveFollowingFace Method

Returns a curve that corresponds to this edge as oriented in its topological direction on the specified face.

## Syntax (C#)
```csharp
public Curve AsCurveFollowingFace(
	Face faceForDir
)
```

## Parameters
- **faceForDir** (`Autodesk.Revit.DB.Face`) - Specifies the face, on which the curve will follow the topological direction of the edge.

## Returns
It can be an Arc, Line, or HermiteSpline.

## Remarks
Evaluating the edge using EvaluateOnFace gives the same result as evaluating the curve returned by AsCurveFollowingFace with a normalized 
curve parameter. When a Hermite spline is returned, the two evaluated points will be approximately equal.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when the specified faceForDir is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the specified faceForDir is not one of the faces for this edge.

