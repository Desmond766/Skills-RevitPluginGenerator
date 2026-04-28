---
kind: method
id: M:Autodesk.Revit.DB.UnitFormatUtils.TryParse(Autodesk.Revit.DB.Units,Autodesk.Revit.DB.ForgeTypeId,System.String,System.Double@,System.String@)
source: html/894fa2c9-c0f8-0ff4-95e0-a8d562d2747f.htm
---
# Autodesk.Revit.DB.UnitFormatUtils.TryParse Method

Parses a formatted string into a number with units if possible.

## Syntax (C#)
```csharp
public static bool TryParse(
	Units units,
	ForgeTypeId specTypeId,
	string stringToParse,
	out double value,
	out string message
)
```

## Parameters
- **units** (`Autodesk.Revit.DB.Units`) - The units formatting settings, typically obtained from Document.GetUnits() .
- **specTypeId** (`Autodesk.Revit.DB.ForgeTypeId`) - Identifier of the target spec for the value.
- **stringToParse** (`System.String`) - The string to parse.
- **value** (`System.Double %`) - The parsed value. Ignore this value if the function returns false.
- **message** (`System.String %`) - A localized message that, if the parsing fails, explains the reason for failure.

## Returns
True if the string can be parsed, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - specTypeId is not a measurable spec identifier. See UnitUtils.IsMeasurableSpec(ForgeTypeId).
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

