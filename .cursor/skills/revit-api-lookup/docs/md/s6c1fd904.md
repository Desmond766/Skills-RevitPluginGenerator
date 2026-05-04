---
kind: method
id: M:Autodesk.Revit.DB.OverrideGraphicSettings.SetCutBackgroundPatternColor(Autodesk.Revit.DB.Color)
source: html/0d7868f4-fc48-a2e3-6eb2-e6e6e39df793.htm
---
# Autodesk.Revit.DB.OverrideGraphicSettings.SetCutBackgroundPatternColor Method

Sets the override color of the background pattern of cut faces.

## Syntax (C#)
```csharp
public OverrideGraphicSettings SetCutBackgroundPatternColor(
	Color color
)
```

## Parameters
- **color** (`Autodesk.Revit.DB.Color`) - Value of the cut face background color for the override. InvalidColorValue means no override is set.

## Returns
Reference to the changed object.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

