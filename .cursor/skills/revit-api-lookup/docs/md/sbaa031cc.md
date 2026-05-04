---
kind: method
id: M:Autodesk.Revit.DB.FormatOptions.CanSuppressSpaces(Autodesk.Revit.DB.ForgeTypeId)
source: html/b5634679-ed3f-0fd0-333e-968ec8469a59.htm
---
# Autodesk.Revit.DB.FormatOptions.CanSuppressSpaces Method

Checks whether spaces can be suppressed for a given unit.

## Syntax (C#)
```csharp
public static bool CanSuppressSpaces(
	ForgeTypeId unitTypeId
)
```

## Parameters
- **unitTypeId** (`Autodesk.Revit.DB.ForgeTypeId`) - Identifier of the unit.

## Returns
True if spaces can be suppressed, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - unitTypeId is not a unit identifier. See UnitUtils.IsUnit(ForgeTypeId) and UnitUtils.GetUnitTypeId(DisplayUnitType).
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

