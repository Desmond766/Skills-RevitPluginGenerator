---
kind: method
id: M:Autodesk.Revit.DB.UnitFormatUtils.TryParse(Autodesk.Revit.DB.Units,Autodesk.Revit.DB.ForgeTypeId,System.String,System.Double@)
source: html/94aa0fc7-a9f7-6961-260f-88838f791637.htm
---
# Autodesk.Revit.DB.UnitFormatUtils.TryParse Method

Parses a formatted string into a number with units if possible.

## Syntax (C#)
```csharp
public static bool TryParse(
	Units units,
	ForgeTypeId specTypeId,
	string stringToParse,
	out double value
)
```

## Parameters
- **units** (`Autodesk.Revit.DB.Units`) - The units formatting settings, typically obtained from Document.GetUnits() .
- **specTypeId** (`Autodesk.Revit.DB.ForgeTypeId`) - Identifier of the target spec for the value.
- **stringToParse** (`System.String`) - The string to parse.
- **value** (`System.Double %`) - The parsed value. Ignore this value if the function returns false.

## Returns
True if the string can be parsed, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - specTypeId is not a measurable spec identifier. See UnitUtils.IsMeasurableSpec(ForgeTypeId).
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

