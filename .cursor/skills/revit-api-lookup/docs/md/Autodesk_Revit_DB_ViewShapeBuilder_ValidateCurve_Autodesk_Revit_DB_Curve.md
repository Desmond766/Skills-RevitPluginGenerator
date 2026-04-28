---
kind: method
id: M:Autodesk.Revit.DB.ViewShapeBuilder.ValidateCurve(Autodesk.Revit.DB.Curve)
source: html/c8ebf475-8f7c-100f-bd1f-351dba4a1149.htm
---
# Autodesk.Revit.DB.ViewShapeBuilder.ValidateCurve Method

Validates curve to be added to the view-specific shape being constructed. Called by AddCurve() to validate input. Expects a valid view normal to be set prior to the call.

## Syntax (C#)
```csharp
public bool ValidateCurve(
	Curve GCurve
)
```

## Parameters
- **GCurve** (`Autodesk.Revit.DB.Curve`) - Curve object to be validated.

## Returns
True is %GCurve% is acceptable as a part of view-specific shape representation being built.

## Remarks
This function may be used to pre-validate the geometry being added to avoid AddCurve() throwing an InvalidArgumentException
 Validation conditions depend on the type of view for which the shape representation is intended.
 For plan views, a curve is expected to be planar and non-degenerate (e.g., NOT a circle of zero radius).

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

