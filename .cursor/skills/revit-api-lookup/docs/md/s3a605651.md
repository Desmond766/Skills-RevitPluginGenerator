---
kind: method
id: M:Autodesk.Revit.DB.DirectShapeType.AddReferenceCurve(Autodesk.Revit.DB.Curve)
source: html/7ea1eedd-87bb-e0db-306c-756c14edfa0b.htm
---
# Autodesk.Revit.DB.DirectShapeType.AddReferenceCurve Method

Adds a reference curve to the DirectShapeType.

## Syntax (C#)
```csharp
public void AddReferenceCurve(
	Curve refCurve
)
```

## Parameters
- **refCurve** (`Autodesk.Revit.DB.Curve`) - The geometry of the new reference curve.
 First case: The input curve's bounds are set. The resulting reference curve that is added to the
 DirectShapeType will be displayed with those bounds. Note that the specified bounds must not be degenerate.
 Second case: The input curve is unbounded. Reasonable bounds are therefore automatically calculated
 and applied to the input curve. The automatic bounds are based on the host direct shape's geometry.
 Note that only lines and splines may be unbounded. You must specify valid bounds for all other curve types.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - refCurve cannot be used for creating a reference curve.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

