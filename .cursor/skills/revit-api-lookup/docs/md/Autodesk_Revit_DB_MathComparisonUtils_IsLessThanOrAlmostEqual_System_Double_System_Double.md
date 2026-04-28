---
kind: method
id: M:Autodesk.Revit.DB.MathComparisonUtils.IsLessThanOrAlmostEqual(System.Double,System.Double)
source: html/bf4aabed-0dc3-54a3-af2d-3e407b305ece.htm
---
# Autodesk.Revit.DB.MathComparisonUtils.IsLessThanOrAlmostEqual Method

Checks if value1 is less than or almost equal to value2, using the internal tolerance.

## Syntax (C#)
```csharp
public static bool IsLessThanOrAlmostEqual(
	double value1,
	double value2
)
```

## Parameters
- **value1** (`System.Double`) - The first value.
- **value2** (`System.Double`) - The second value.

## Returns
True if value1 is less than or almost equal to value2, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given value for value1 is not finite
 -or-
 The given value for value2 is not finite

