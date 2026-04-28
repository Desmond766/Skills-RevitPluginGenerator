---
kind: method
id: M:Autodesk.Revit.DB.Face.GetEdgesAsCurveLoops
source: html/4410caa7-3f65-1aed-763c-4f23510d6c17.htm
---
# Autodesk.Revit.DB.Face.GetEdgesAsCurveLoops Method

Returns a list of closed curve loops that correspond to the edge loops of the face. 
Curves in each curve loop correspond to individual edges.

## Syntax (C#)
```csharp
public IList<CurveLoop> GetEdgesAsCurveLoops()
```

## Returns
A list of closed curve loops, that correspond edges of face.

## Remarks
Orientations of the curves and curve loops match the orientations of the face's edges and edge loops.
The order of the CurveLoops should be considered as arbitrary.

