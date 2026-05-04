---
kind: method
id: M:Autodesk.Revit.DB.CurveLoop.Append(Autodesk.Revit.DB.Curve)
source: html/9ecde812-a299-b823-35fc-4428e9298602.htm
---
# Autodesk.Revit.DB.CurveLoop.Append Method

Append the curve to this loop.

## Syntax (C#)
```csharp
public void Append(
	Curve curve
)
```

## Parameters
- **curve** (`Autodesk.Revit.DB.Curve`) - The curve.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The input curve points to a helical curve and is not supported for this operation.
 -or-
 Throws if the input curve makes the loop not contiguous.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

