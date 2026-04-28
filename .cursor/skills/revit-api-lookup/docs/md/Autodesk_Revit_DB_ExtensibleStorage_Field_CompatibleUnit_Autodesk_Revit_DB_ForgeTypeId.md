---
kind: method
id: M:Autodesk.Revit.DB.ExtensibleStorage.Field.CompatibleUnit(Autodesk.Revit.DB.ForgeTypeId)
source: html/e35028c0-a9e5-fb29-568e-c3b9663eecb5.htm
---
# Autodesk.Revit.DB.ExtensibleStorage.Field.CompatibleUnit Method

Checks if the specified unit is compatible with the field description.

## Syntax (C#)
```csharp
public bool CompatibleUnit(
	ForgeTypeId unitTypeId
)
```

## Parameters
- **unitTypeId** (`Autodesk.Revit.DB.ForgeTypeId`) - The unit to check.

## Returns
True if the unit is compatible, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

