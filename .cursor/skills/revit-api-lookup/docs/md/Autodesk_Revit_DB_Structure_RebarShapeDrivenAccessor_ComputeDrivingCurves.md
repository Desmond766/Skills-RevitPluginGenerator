---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarShapeDrivenAccessor.ComputeDrivingCurves
source: html/46288659-93f8-62ee-2d7b-94b7a84e44ab.htm
---
# Autodesk.Revit.DB.Structure.RebarShapeDrivenAccessor.ComputeDrivingCurves Method

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

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This RebarShapeDrivenAccessor doesn't contain a valid rebar reference.

