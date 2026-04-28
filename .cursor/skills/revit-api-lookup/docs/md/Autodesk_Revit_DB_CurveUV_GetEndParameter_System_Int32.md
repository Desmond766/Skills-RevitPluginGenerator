---
kind: method
id: M:Autodesk.Revit.DB.CurveUV.GetEndParameter(System.Int32)
source: html/daa1ae74-36c8-fcfb-48d9-d9040df6d54f.htm
---
# Autodesk.Revit.DB.CurveUV.GetEndParameter Method

Gets the raw parameter value at the start or end of this curve.

## Syntax (C#)
```csharp
public double GetEndParameter(
	int index
)
```

## Parameters
- **index** (`System.Int32`) - Use 0 for the start parameter, 1 for the end parameter of the curve.

## Returns
The raw parameter value at the start or end of this curve.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The given value for index is not 0 or 1.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This curve is unbound and does not have start and end points.

