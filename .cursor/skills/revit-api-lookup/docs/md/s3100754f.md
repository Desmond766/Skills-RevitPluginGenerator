---
kind: method
id: M:Autodesk.Revit.DB.OverrideGraphicSettings.SetCutForegroundPatternId(Autodesk.Revit.DB.ElementId)
source: html/3bb99a25-ae9d-6b16-3bc5-8f281f5e50bb.htm
---
# Autodesk.Revit.DB.OverrideGraphicSettings.SetCutForegroundPatternId Method

Sets the ElementId of the cut face foreground pattern override.
 The fill pattern must be a drafting pattern.
 A value of InvalidElementId means no override is set.

## Syntax (C#)
```csharp
public OverrideGraphicSettings SetCutForegroundPatternId(
	ElementId fillPatternId
)
```

## Parameters
- **fillPatternId** (`Autodesk.Revit.DB.ElementId`) - Value of the cut face foreground fill pattern override.

## Returns
Reference to the changed object.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

