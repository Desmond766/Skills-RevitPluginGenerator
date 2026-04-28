---
kind: method
id: M:Autodesk.Revit.DB.MathComparisonUtils.IsLessThan(System.Double,System.Double)
source: html/1d49f8c2-2eba-c7b3-1d04-f2927f10e5e7.htm
---
# Autodesk.Revit.DB.MathComparisonUtils.IsLessThan Method

Checks if value1 is strictly less than value2, using the internal tolerance.

## Syntax (C#)
```csharp
public static bool IsLessThan(
	double value1,
	double value2
)
```

## Parameters
- **value1** (`System.Double`) - The first value.
- **value2** (`System.Double`) - The second value.

## Returns
True if value1 is strictly less than value2, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given value for value1 is not finite
 -or-
 The given value for value2 is not finite

