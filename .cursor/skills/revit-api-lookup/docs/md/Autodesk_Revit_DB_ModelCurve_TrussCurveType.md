---
kind: property
id: P:Autodesk.Revit.DB.ModelCurve.TrussCurveType
source: html/e1756e73-38e2-91fd-d978-dd106fd8f109.htm
---
# Autodesk.Revit.DB.ModelCurve.TrussCurveType Property

The truss curve type of this model curve.

## Syntax (C#)
```csharp
public TrussCurveType TrussCurveType { get; set; }
```

## Remarks
This property is applicable only to curves in Truss families.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - Thrown when the assigned value for TrussCurveType is invalid.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when attempting to set this property to a curve not in a truss family.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when attempting to change truss curves to NonTrussCurve, or when
 the truss curve type may not be applied to curves of this shape (webs must be linear, and chords must be linear or arc).

