---
kind: method
id: M:Autodesk.Revit.DB.OverrideGraphicSettings.SetSurfaceBackgroundPatternColor(Autodesk.Revit.DB.Color)
source: html/0b7277de-fde8-5b93-c56d-78c4dddedf84.htm
---
# Autodesk.Revit.DB.OverrideGraphicSettings.SetSurfaceBackgroundPatternColor Method

Sets the override color of the surface background pattern.

## Syntax (C#)
```csharp
public OverrideGraphicSettings SetSurfaceBackgroundPatternColor(
	Color color
)
```

## Parameters
- **color** (`Autodesk.Revit.DB.Color`) - Value of the surface background color for the override. InvalidColorValue means no override is set.

## Returns
Reference to the changed object.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

