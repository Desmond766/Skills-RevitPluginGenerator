---
kind: method
id: M:Autodesk.Revit.DB.BaseImportOptions.SetDefaultLengthUnit(Autodesk.Revit.DB.ForgeTypeId)
source: html/618deae5-14bc-98b2-f67d-3db45503c7a3.htm
---
# Autodesk.Revit.DB.BaseImportOptions.SetDefaultLengthUnit Method

Set the default length unit used for importing unitless files.

## Syntax (C#)
```csharp
public void SetDefaultLengthUnit(
	ForgeTypeId specTypeId
)
```

## Parameters
- **specTypeId** (`Autodesk.Revit.DB.ForgeTypeId`) - The default length unit.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given specTypeId is not a supported unit of length.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

