---
kind: method
id: M:Autodesk.Revit.DB.FormatOptions.CanUsePlusPrefix(Autodesk.Revit.DB.ForgeTypeId)
source: html/30600192-d978-dc19-ef6b-a47aeeb097a8.htm
---
# Autodesk.Revit.DB.FormatOptions.CanUsePlusPrefix Method

Checks whether a plus prefix can be displayed for a given unit.

## Syntax (C#)
```csharp
public static bool CanUsePlusPrefix(
	ForgeTypeId unitTypeId
)
```

## Parameters
- **unitTypeId** (`Autodesk.Revit.DB.ForgeTypeId`) - Identifier of the unit.

## Returns
True if a plus prefix can be displayed, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - unitTypeId is not a unit identifier. See UnitUtils.IsUnit(ForgeTypeId) and UnitUtils.GetUnitTypeId(DisplayUnitType).
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

