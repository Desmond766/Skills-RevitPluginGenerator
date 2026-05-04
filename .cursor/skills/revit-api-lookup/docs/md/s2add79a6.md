---
kind: method
id: M:Autodesk.Revit.DB.WireframeBuilder.ValidateCurve(Autodesk.Revit.DB.Curve)
source: html/a0cf31ee-9297-17ae-f947-dfdcb4c85ebc.htm
---
# Autodesk.Revit.DB.WireframeBuilder.ValidateCurve Method

Validates curve to be added to the wireframe shape being constructed. Used by addCurve to validate input.
 This function may be used to pre-validate the geometry being added to avoid an exception from AddCurve().

## Syntax (C#)
```csharp
public static bool ValidateCurve(
	Curve GCurve
)
```

## Parameters
- **GCurve** (`Autodesk.Revit.DB.Curve`) - Curve object to be validated.

## Returns
True is %GCurve% is acceptable as a part of a wireframe shape representation being built.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

