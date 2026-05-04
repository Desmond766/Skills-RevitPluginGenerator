---
kind: method
id: M:Autodesk.Revit.DB.LabelUtils.GetLabelForUnit(Autodesk.Revit.DB.ForgeTypeId)
source: html/96491567-d6a1-23ed-2d82-673d5b1dfc5b.htm
---
# Autodesk.Revit.DB.LabelUtils.GetLabelForUnit Method

Gets the user-visible name for a unit.

## Syntax (C#)
```csharp
public static string GetLabelForUnit(
	ForgeTypeId unitTypeId
)
```

## Parameters
- **unitTypeId** (`Autodesk.Revit.DB.ForgeTypeId`) - Identifier of the unit to get the user-visible name.

## Remarks
The name is obtained in the current Revit language.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Cannot find DisplayUnitTypeInfo for the given unit identifier.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

