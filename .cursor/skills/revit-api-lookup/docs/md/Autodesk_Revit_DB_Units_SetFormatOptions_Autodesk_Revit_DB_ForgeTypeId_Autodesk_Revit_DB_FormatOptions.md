---
kind: method
id: M:Autodesk.Revit.DB.Units.SetFormatOptions(Autodesk.Revit.DB.ForgeTypeId,Autodesk.Revit.DB.FormatOptions)
source: html/55408411-e776-857d-a6b8-895b7f718318.htm
---
# Autodesk.Revit.DB.Units.SetFormatOptions Method

Sets the default FormatOptions for a spec.

## Syntax (C#)
```csharp
public void SetFormatOptions(
	ForgeTypeId specTypeId,
	FormatOptions options
)
```

## Parameters
- **specTypeId** (`Autodesk.Revit.DB.ForgeTypeId`) - Identifier of the spec.
- **options** (`Autodesk.Revit.DB.FormatOptions`) - The FormatOptions.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - specTypeId is not a measurable spec identifier. See UnitUtils.IsMeasurableSpec(ForgeTypeId).
 -or-
 FormatOptions cannot be modified for specTypeId. See Units.IsModifiableSpec(ForgeTypeId) and Units.GetModifiableSpecs().
 -or-
 UseDefault is true in options.
 -or-
 The unit in options is not valid for specTypeId. See UnitUtils.IsValidUnit(ForgeTypeId, ForgeTypeId) and UnitUtils.GetValidUnits(ForgeTypeId).
 -or-
 The rounding method in options is not set to Nearest.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

