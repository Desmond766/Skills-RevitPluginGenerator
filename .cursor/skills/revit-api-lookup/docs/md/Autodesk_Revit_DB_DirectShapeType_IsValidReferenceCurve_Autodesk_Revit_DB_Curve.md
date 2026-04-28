---
kind: method
id: M:Autodesk.Revit.DB.DirectShapeType.IsValidReferenceCurve(Autodesk.Revit.DB.Curve)
source: html/ad764aa6-881d-658f-633c-8f52c2ffbbc8.htm
---
# Autodesk.Revit.DB.DirectShapeType.IsValidReferenceCurve Method

Validates that the input curve is suitable for creating a direct shape type reference curve.
 Bounded and unbounded lines are accepted.
 Other bounded and unbounded curve types with natural bounds are accepted if they are not closed.
 Unbounded periodic curves are not allowed.

## Syntax (C#)
```csharp
public static bool IsValidReferenceCurve(
	Curve curve
)
```

## Parameters
- **curve** (`Autodesk.Revit.DB.Curve`) - The curve to test.

## Returns
True if the input curve point can be used to create a direct shape reference curve, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

