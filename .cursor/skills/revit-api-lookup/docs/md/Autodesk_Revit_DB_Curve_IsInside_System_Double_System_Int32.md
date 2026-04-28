---
kind: method
id: M:Autodesk.Revit.DB.Curve.IsInside(System.Double,System.Int32@)
zh: 曲线
source: html/64b9685d-b790-d2cb-f9f7-7184669a9ee0.htm
---
# Autodesk.Revit.DB.Curve.IsInside Method

**中文**: 曲线

Indicates whether the specified parameter value is within this curve's bounds and outputs the end index.

## Syntax (C#)
```csharp
public bool IsInside(
	double parameter,
	out int end
)
```

## Parameters
- **parameter** (`System.Double`) - The raw curve parameter to be evaluated.
- **end** (`System.Int32 %`) - The end index is equal to 0 for the start point, 1 for the end point, or -1 if the parameter is not at the end.

## Returns
True if the parameter is within the curve's bounds, otherwise false.

## Remarks
Always returns true if this curve is unbound.

