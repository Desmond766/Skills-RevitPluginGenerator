---
kind: method
id: M:Autodesk.Revit.DB.OverrideGraphicSettings.SetCutLineWeight(System.Int32)
source: html/0d483b50-a4ab-13ee-9ef6-47d3734ba186.htm
---
# Autodesk.Revit.DB.OverrideGraphicSettings.SetCutLineWeight Method

Sets the cut surface line weight.

## Syntax (C#)
```csharp
public OverrideGraphicSettings SetCutLineWeight(
	int lineWeight
)
```

## Parameters
- **lineWeight** (`System.Int32`) - Value of the cut surface line weight for the override. InvalidPenNumber means no override is set.

## Returns
Reference to the changed object.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Line weight must be a positive integer less than 17 or invalidPenNumber.

