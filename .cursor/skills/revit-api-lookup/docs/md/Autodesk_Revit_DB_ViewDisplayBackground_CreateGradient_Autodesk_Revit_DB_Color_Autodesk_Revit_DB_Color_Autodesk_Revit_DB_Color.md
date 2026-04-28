---
kind: method
id: M:Autodesk.Revit.DB.ViewDisplayBackground.CreateGradient(Autodesk.Revit.DB.Color,Autodesk.Revit.DB.Color,Autodesk.Revit.DB.Color)
source: html/3562ab2f-4e33-b301-d2ac-528ec715582f.htm
---
# Autodesk.Revit.DB.ViewDisplayBackground.CreateGradient Method

Creates an object that can be passed to View.SetBackground method
 to set the background of the Gradient type.

## Syntax (C#)
```csharp
public static ViewDisplayBackground CreateGradient(
	Color skyColor,
	Color horizonColor,
	Color groundColor
)
```

## Parameters
- **skyColor** (`Autodesk.Revit.DB.Color`) - The top of the sky gradient if the sky is visible.
- **horizonColor** (`Autodesk.Revit.DB.Color`) - The bottom or the sky gradient if the sky is visible,
 or the top of the ground gradient otherwise.
- **groundColor** (`Autodesk.Revit.DB.Color`) - The ground color if the sky is visible (ground shown in uniform color),
 or the bottom of the ground gradient if the sky is not visible.

## Returns
New background object to pass to View.SetBackground .

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

