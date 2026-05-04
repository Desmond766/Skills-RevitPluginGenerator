---
kind: method
id: M:Autodesk.Revit.DB.UnitFormatUtils.TryParse(Autodesk.Revit.DB.Units,Autodesk.Revit.DB.ForgeTypeId,System.String,Autodesk.Revit.DB.ValueParsingOptions,System.Double@)
source: html/8fceae0f-108c-4562-73ac-3b88348a893f.htm
---
# Autodesk.Revit.DB.UnitFormatUtils.TryParse Method

Parses a formatted string into a number with units if possible.

## Syntax (C#)
```csharp
public static bool TryParse(
	Units units,
	ForgeTypeId specTypeId,
	string stringToParse,
	ValueParsingOptions valueParsingOptions,
	out double value
)
```

## Parameters
- **units** (`Autodesk.Revit.DB.Units`) - The units formatting settings, typically obtained from Document.GetUnits() .
- **specTypeId** (`Autodesk.Revit.DB.ForgeTypeId`) - Identifier of the target spec for the value.
- **stringToParse** (`System.String`) - The string to parse.
- **valueParsingOptions** (`Autodesk.Revit.DB.ValueParsingOptions`) - Additional parsing options.
- **value** (`System.Double %`) - The parsed value. Ignore this value if the function returns false.

## Returns
True if the string can be parsed, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - specTypeId is not a measurable spec identifier. See UnitUtils.IsMeasurableSpec(ForgeTypeId).
 -or-
 The unit in the FormatOptions in valueParsingOptions is not a valid unit for specTypeId. See UnitUtils.IsValidUnit(ForgeTypeId, ForgeTypeId) and UnitUtils.GetValidUnits(ForgeTypeId).
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

