---
kind: method
id: M:Autodesk.Revit.DB.Structure.AnalyticalElement.GetCurve
source: html/1eebc63e-4b20-a2a1-3537-283e2d284ee4.htm
---
# Autodesk.Revit.DB.Structure.AnalyticalElement.GetCurve Method

Returns the curve of the Analytical Element.

## Syntax (C#)
```csharp
public Curve GetCurve()
```

## Returns
The curve of the Analytical Element.

## Remarks
If the Analytical Element cannot be expressed as a single curve, an exception is thrown.

## Exceptions
- **Autodesk.Revit.Exceptions.InapplicableDataException** - This AnalyticalElement contains more than one single curve.

