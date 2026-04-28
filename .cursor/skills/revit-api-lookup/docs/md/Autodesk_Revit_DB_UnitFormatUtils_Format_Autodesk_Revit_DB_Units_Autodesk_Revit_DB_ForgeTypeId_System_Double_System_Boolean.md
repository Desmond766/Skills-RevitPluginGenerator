---
kind: method
id: M:Autodesk.Revit.DB.UnitFormatUtils.Format(Autodesk.Revit.DB.Units,Autodesk.Revit.DB.ForgeTypeId,System.Double,System.Boolean)
source: html/e416927f-551c-97a9-d5cf-ee255d9bdf2b.htm
---
# Autodesk.Revit.DB.UnitFormatUtils.Format Method

Formats a number with units into a string.

## Syntax (C#)
```csharp
public static string Format(
	Units units,
	ForgeTypeId specTypeId,
	double value,
	bool forEditing
)
```

## Parameters
- **units** (`Autodesk.Revit.DB.Units`) - The units formatting settings, typically obtained from Document.GetUnits() .
- **specTypeId** (`Autodesk.Revit.DB.ForgeTypeId`) - Identifier of the spec of the value to format.
- **value** (`System.Double`) - The value to format, in Revit's internal units.
- **forEditing** (`System.Boolean`) - True if the formatting should be modified as necessary so that the formatted string can be successfully parsed, for example by suppressing digit grouping. False if unmodified settings should be used, suitable for display only.

## Returns
The formatted string.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - specTypeId is not a measurable spec identifier. See UnitUtils.IsMeasurableSpec(ForgeTypeId).
 -or-
 The given value for value is not finite
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

