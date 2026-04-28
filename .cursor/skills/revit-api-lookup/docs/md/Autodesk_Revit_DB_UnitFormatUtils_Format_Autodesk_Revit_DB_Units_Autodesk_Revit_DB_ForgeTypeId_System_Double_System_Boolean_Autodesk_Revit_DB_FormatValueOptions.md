---
kind: method
id: M:Autodesk.Revit.DB.UnitFormatUtils.Format(Autodesk.Revit.DB.Units,Autodesk.Revit.DB.ForgeTypeId,System.Double,System.Boolean,Autodesk.Revit.DB.FormatValueOptions)
source: html/2aa08848-a28b-6fd9-79ef-d708b79ec28d.htm
---
# Autodesk.Revit.DB.UnitFormatUtils.Format Method

Formats a number with units into a string.

## Syntax (C#)
```csharp
public static string Format(
	Units units,
	ForgeTypeId specTypeId,
	double value,
	bool forEditing,
	FormatValueOptions formatValueOptions
)
```

## Parameters
- **units** (`Autodesk.Revit.DB.Units`) - The units formatting settings, typically obtained from Document.GetUnits() .
- **specTypeId** (`Autodesk.Revit.DB.ForgeTypeId`) - Identifier of the spec of the value to format.
- **value** (`System.Double`) - The value to format, in Revit's internal units.
- **forEditing** (`System.Boolean`) - True if the formatting should be modified as necessary so that the formatted string can be successfully parsed, for example by suppressing digit grouping. False if unmodified settings should be used, suitable for display only.
- **formatValueOptions** (`Autodesk.Revit.DB.FormatValueOptions`) - Additional formatting options.

## Returns
The formatted string.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - specTypeId is not a measurable spec identifier. See UnitUtils.IsMeasurableSpec(ForgeTypeId).
 -or-
 The given value for value is not finite
 -or-
 The unit in the FormatOptions in formatValueOptions is not a valid unit for specTypeId. See UnitUtils.IsValidUnit(ForgeTypeId, ForgeTypeId) and UnitUtils.GetValidUnits(ForgeTypeId).
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

