---
kind: method
id: M:Autodesk.Revit.DB.MathComparisonUtils.IsAlmostZero(System.Double)
source: html/a65ae156-b36f-3737-11d6-2306d2f4b788.htm
---
# Autodesk.Revit.DB.MathComparisonUtils.IsAlmostZero Method

Checks if value is almost zero, using the internal tolerance.

## Syntax (C#)
```csharp
public static bool IsAlmostZero(
	double value
)
```

## Parameters
- **value** (`System.Double`) - The value to check.

## Returns
True if value is almost zero, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given value for value is not finite

