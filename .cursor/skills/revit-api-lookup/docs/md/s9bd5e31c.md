---
kind: method
id: M:Autodesk.Revit.DB.FormatOptions.SetUnitTypeId(Autodesk.Revit.DB.ForgeTypeId)
source: html/756cf4e7-b124-2703-3335-35f376f2c676.htm
---
# Autodesk.Revit.DB.FormatOptions.SetUnitTypeId Method

Sets the unit used to quantify values.

## Syntax (C#)
```csharp
public FormatOptions SetUnitTypeId(
	ForgeTypeId unitTypeId
)
```

## Parameters
- **unitTypeId** (`Autodesk.Revit.DB.ForgeTypeId`) - The unit identifier.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - unitTypeId is not a unit identifier. See UnitUtils.IsUnit(ForgeTypeId) and UnitUtils.GetUnitTypeId(DisplayUnitType).
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - UseDefault is true in this FormatOptions.

