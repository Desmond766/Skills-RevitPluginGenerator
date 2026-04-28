---
kind: method
id: M:Autodesk.Revit.DB.Curve.IsInside(System.Double)
zh: 曲线
source: html/2782b130-915f-8467-22f1-629b9e0c1574.htm
---
# Autodesk.Revit.DB.Curve.IsInside Method

**中文**: 曲线

Indicates whether the specified parameter value is within this curve's bounds.

## Syntax (C#)
```csharp
public bool IsInside(
	double parameter
)
```

## Parameters
- **parameter** (`System.Double`) - The raw curve parameter to be evaluated.

## Returns
True if the parameter is within the bounds, otherwise false.

## Remarks
Always returns true if this curve is unbound.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the specified parameter is infinite.

