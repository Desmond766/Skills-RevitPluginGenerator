---
kind: method
id: M:Autodesk.Revit.DB.MathComparisonUtils.IsGreaterThanOrAlmostEqual(System.Double,System.Double)
source: html/49c53183-8e50-d493-318d-33242424be4d.htm
---
# Autodesk.Revit.DB.MathComparisonUtils.IsGreaterThanOrAlmostEqual Method

Checks if value1 is greater than or almost equal to value2, using the internal tolerance.

## Syntax (C#)
```csharp
public static bool IsGreaterThanOrAlmostEqual(
	double value1,
	double value2
)
```

## Parameters
- **value1** (`System.Double`) - The first value.
- **value2** (`System.Double`) - The second value.

## Returns
True if value1 is greater than or almost equal to value2, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given value for value1 is not finite
 -or-
 The given value for value2 is not finite

