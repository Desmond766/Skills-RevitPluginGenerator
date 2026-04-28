---
kind: method
id: M:Autodesk.Revit.DB.UnitUtils.IsMeasurableSpec(Autodesk.Revit.DB.ForgeTypeId)
source: html/4c3009eb-fd4e-18a3-cc0b-58a3883d6143.htm
---
# Autodesk.Revit.DB.UnitUtils.IsMeasurableSpec Method

Checks whether a ForgeTypeId identifies a spec associated with units of measurement.

## Syntax (C#)
```csharp
public static bool IsMeasurableSpec(
	ForgeTypeId specTypeId
)
```

## Parameters
- **specTypeId** (`Autodesk.Revit.DB.ForgeTypeId`) - The identifier to check.

## Returns
True if the ForgeTypeId identifies a measurable spec, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

