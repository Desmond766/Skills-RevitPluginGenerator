---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarContainerItem.ComputeDrivingCurves
source: html/b2c67a47-1b2d-ed45-eb9a-8b88087d0cfb.htm
---
# Autodesk.Revit.DB.Structure.RebarContainerItem.ComputeDrivingCurves Method

Compute the driving curves.

## Syntax (C#)
```csharp
public IList<Curve> ComputeDrivingCurves()
```

## Returns
Returns an empty array if an error is encountered.

## Remarks
The driving curves are the ones that appear in rebar sketch
 mode. They include lines and arcs that drive the shape, but
 exclude fillets and hooks. They always lie in a plane--
 if the bar is 3D, these curves are a subset or a projection.
 They are also used for shape matching.

