---
kind: method
id: M:Autodesk.Revit.DB.OverrideGraphicSettings.SetCutBackgroundPatternId(Autodesk.Revit.DB.ElementId)
source: html/f13852d7-cc6a-773d-a6c5-e063833e4a5c.htm
---
# Autodesk.Revit.DB.OverrideGraphicSettings.SetCutBackgroundPatternId Method

Sets the ElementId of the cut face background pattern override.
 The fill pattern must be a drafting pattern.
 A value of InvalidElementId means no override is set.

## Syntax (C#)
```csharp
public OverrideGraphicSettings SetCutBackgroundPatternId(
	ElementId fillPatternId
)
```

## Parameters
- **fillPatternId** (`Autodesk.Revit.DB.ElementId`) - Value of the cut face background fill pattern override.

## Returns
Reference to the changed object.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

