---
kind: method
id: M:Autodesk.Revit.DB.OverrideGraphicSettings.SetProjectionLineWeight(System.Int32)
source: html/f9365fee-0031-260d-955a-7796c09b0382.htm
---
# Autodesk.Revit.DB.OverrideGraphicSettings.SetProjectionLineWeight Method

Sets the projection surface line weight.

## Syntax (C#)
```csharp
public OverrideGraphicSettings SetProjectionLineWeight(
	int lineWeight
)
```

## Parameters
- **lineWeight** (`System.Int32`) - Value of the projection surface line weight for the override. InvalidPenNumber means no override is set.

## Returns
Reference to the changed object.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Line weight must be a positive integer less than 17 or invalidPenNumber.

