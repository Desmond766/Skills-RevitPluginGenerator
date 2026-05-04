---
kind: method
id: M:Autodesk.Revit.DB.MathComparisonUtils.IsGreaterThan(System.Double,System.Double)
source: html/3d7add45-c7bf-279c-dbe9-d99556add8fa.htm
---
# Autodesk.Revit.DB.MathComparisonUtils.IsGreaterThan Method

Checks if value1 is strictly greater than value2, using the internal tolerance.

## Syntax (C#)
```csharp
public static bool IsGreaterThan(
	double value1,
	double value2
)
```

## Parameters
- **value1** (`System.Double`) - The first value.
- **value2** (`System.Double`) - The second value.

## Returns
True if value1 is strictly greater than value2, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given value for value1 is not finite
 -or-
 The given value for value2 is not finite

