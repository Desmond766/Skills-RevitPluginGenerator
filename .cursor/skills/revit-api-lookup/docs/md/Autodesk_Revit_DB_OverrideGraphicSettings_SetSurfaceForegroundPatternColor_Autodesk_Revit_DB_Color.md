---
kind: method
id: M:Autodesk.Revit.DB.OverrideGraphicSettings.SetSurfaceForegroundPatternColor(Autodesk.Revit.DB.Color)
source: html/d2557a68-b1dd-c28a-1e63-81be6c186b2d.htm
---
# Autodesk.Revit.DB.OverrideGraphicSettings.SetSurfaceForegroundPatternColor Method

Sets the override color of the surface foreground pattern.

## Syntax (C#)
```csharp
public OverrideGraphicSettings SetSurfaceForegroundPatternColor(
	Color color
)
```

## Parameters
- **color** (`Autodesk.Revit.DB.Color`) - Value of the surface foreground color for the override. InvalidColorValue means no override is set.

## Returns
Reference to the changed object.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

