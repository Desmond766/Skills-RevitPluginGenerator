---
kind: method
id: M:Autodesk.Revit.DB.FormatOptions.IsValidAccuracy(Autodesk.Revit.DB.ForgeTypeId,System.Double)
source: html/50a5534d-a99f-cdfa-0259-431c0fcc7cc3.htm
---
# Autodesk.Revit.DB.FormatOptions.IsValidAccuracy Method

Checks whether an accuracy is valid for a given unit.

## Syntax (C#)
```csharp
public static bool IsValidAccuracy(
	ForgeTypeId unitTypeId,
	double accuracy
)
```

## Parameters
- **unitTypeId** (`Autodesk.Revit.DB.ForgeTypeId`) - Identifier of the unit.
- **accuracy** (`System.Double`) - The accuracy to check.

## Returns
True if the accuracy is valid, false otherwise.

## Remarks
See the Accuracy property for details on
 valid accuracy values.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - unitTypeId is not a unit identifier. See UnitUtils.IsUnit(ForgeTypeId) and UnitUtils.GetUnitTypeId(DisplayUnitType).
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

