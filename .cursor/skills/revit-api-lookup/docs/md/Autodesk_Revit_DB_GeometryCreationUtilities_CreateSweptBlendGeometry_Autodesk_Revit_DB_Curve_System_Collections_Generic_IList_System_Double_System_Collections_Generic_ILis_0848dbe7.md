---
kind: method
id: M:Autodesk.Revit.DB.GeometryCreationUtilities.CreateSweptBlendGeometry(Autodesk.Revit.DB.Curve,System.Collections.Generic.IList{System.Double},System.Collections.Generic.IList{Autodesk.Revit.DB.CurveLoop},System.Collections.Generic.IList{System.Collections.Generic.ICollection{Autodesk.Revit.DB.VertexPair}},Autodesk.Revit.DB.SolidOptions)
source: html/2c4b7ce3-676e-ee2d-ebc0-0a9ad57e55d5.htm
---
# Autodesk.Revit.DB.GeometryCreationUtilities.CreateSweptBlendGeometry Method

Creates a solid by simultaneously sweeping and blending two or more closed planar curve loops along a single curve.

## Syntax (C#)
```csharp
public static Solid CreateSweptBlendGeometry(
	Curve pathCurve,
	IList<double> pathParams,
	IList<CurveLoop> profileLoops,
	IList<ICollection<VertexPair>> vertexPairs,
	SolidOptions solidOptions
)
```

## Parameters
- **pathCurve** (`Autodesk.Revit.DB.Curve`) - The sweep path, consisting of a single bounded, open curve.
- **pathParams** (`System.Collections.Generic.IList < Double >`) - An increasing sequence of parameters along the path curve (lying within the curve's bounds).
 These parameters specify the locations of the planes orthogonal to the path that contain the profile loops.
 This array must have the same size as the input array "profileLoops".
- **profileLoops** (`System.Collections.Generic.IList < CurveLoop >`) - Closed, planar curve loops arrayed along the path. No loop may contain just one closed curve - split such loops into two or more curves beforehand.
 The solid will have these profiles as cross-sections at the points specified by the input pathParams. The solid will blend smoothly between the profiles.
 This array must have the same size as the input array "pathParams", and each profile loop must lie in the plane orthogonal to the path at the point specified by the corresponding entry in the input array "pathParams".
 Each profile loop must define a single planar domain and must be free of intersections and degeneracies. No orientation conditions on the loops are imposed.
- **vertexPairs** (`System.Collections.Generic.IList < ICollection < VertexPair >>`) - This input specifies how adjacent profile loops should be connected.
 It must contain one less element than the "profileLoops" input, and entry vertexPairs[idx] specifies how profileLoops[idx] and profileLoops[idx+1] should be connected (indexing starts at 0).
- **solidOptions** (`Autodesk.Revit.DB.SolidOptions`) - The optional information to control the properties of the Solid.

## Returns
The requested solid.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The input pathCurve is a helical curve and is not supported for this operation.
 -or-
 The input argument pathCurve should be bounded.
 The input argument pathCurve should be non-degenerate.
 -or-
 The input argument pathParams should be an increasing array.
 -or-
 The profile CurveLoops do not satisfy the input requirements.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

