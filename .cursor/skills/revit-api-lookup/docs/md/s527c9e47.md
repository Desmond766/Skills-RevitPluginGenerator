---
kind: method
id: M:Autodesk.Revit.DB.Structure.LineLoad.SetCurve(Autodesk.Revit.DB.Curve)
source: html/2066b893-dc5e-7082-adc2-0fef5e397b6e.htm
---
# Autodesk.Revit.DB.Structure.LineLoad.SetCurve Method

Sets the curve for the line load.

## Syntax (C#)
```csharp
public void SetCurve(
	Curve curve
)
```

## Parameters
- **curve** (`Autodesk.Revit.DB.Curve`)

## Remarks
The curve must be bounded.
 The curve can be:
 Line Arc Ellipse

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The input curve is not bound.
 -or-
 The provided curve is not supported.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This LineLoad is not a hosted load.
 -or-
 This LineLoad is a constrained load.

