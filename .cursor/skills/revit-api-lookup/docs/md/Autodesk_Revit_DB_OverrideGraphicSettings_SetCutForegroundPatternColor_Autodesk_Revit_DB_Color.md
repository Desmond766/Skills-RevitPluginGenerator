---
kind: method
id: M:Autodesk.Revit.DB.OverrideGraphicSettings.SetCutForegroundPatternColor(Autodesk.Revit.DB.Color)
source: html/26c3c4ed-96b4-964f-86ef-268345d71ec9.htm
---
# Autodesk.Revit.DB.OverrideGraphicSettings.SetCutForegroundPatternColor Method

Sets the override color of the foreground pattern of cut faces.

## Syntax (C#)
```csharp
public OverrideGraphicSettings SetCutForegroundPatternColor(
	Color color
)
```

## Parameters
- **color** (`Autodesk.Revit.DB.Color`) - Value of the cut face foreground color for the override. InvalidColorValue means no override is set.

## Returns
Reference to the changed object.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

