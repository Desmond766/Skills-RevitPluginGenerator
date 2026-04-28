---
kind: method
id: M:Autodesk.Revit.DB.DirectShape.AddReferenceCurve(Autodesk.Revit.DB.Curve,Autodesk.Revit.DB.DirectShapeReferenceOptions)
source: html/a2d32e9b-f749-7b43-b926-6c7ce54c0b3d.htm
---
# Autodesk.Revit.DB.DirectShape.AddReferenceCurve Method

Adds a reference curve to the DirectShape.

## Syntax (C#)
```csharp
public void AddReferenceCurve(
	Curve refCurve,
	DirectShapeReferenceOptions options
)
```

## Parameters
- **refCurve** (`Autodesk.Revit.DB.Curve`) - The geometry of the new reference curve.
 First case: The input curve's bounds are set. The resulting reference curve that is added to the
 DirectShape will be displayed with those bounds. Note that the specified bounds must not be degenerate.
 Second case: The input curve is unbounded. Reasonable bounds are therefore automatically calculated
 and applied to the input curve. The automatic bounds are based on the host direct shape's geometry.
 Note that only lines and splines may be unbounded. You must specify valid bounds for all other curve types.
- **options** (`Autodesk.Revit.DB.DirectShapeReferenceOptions`) - The options that are used to configure the new reference curve.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - refCurve cannot be used for creating a reference curve.
 -or-
 options cannot be used to add a reference object to this DirectShape.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

