---
kind: method
id: M:Autodesk.Revit.DB.MathComparisonUtils.IsAlmostEqual(System.Double,System.Double)
source: html/d688ce75-8feb-866b-a459-892d0fb95781.htm
---
# Autodesk.Revit.DB.MathComparisonUtils.IsAlmostEqual Method

Checks if two doubles are almost equal, using the internal tolerance.

## Syntax (C#)
```csharp
public static bool IsAlmostEqual(
	double value1,
	double value2
)
```

## Parameters
- **value1** (`System.Double`) - The first value.
- **value2** (`System.Double`) - The second value.

## Returns
True if two doubles are almost equal, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given value for value1 is not finite
 -or-
 The given value for value2 is not finite

