---
kind: method
id: M:Autodesk.Revit.DB.OverrideGraphicSettings.SetProjectionLineColor(Autodesk.Revit.DB.Color)
source: html/6b780d28-87fb-2ba6-04fa-f973d85ca552.htm
---
# Autodesk.Revit.DB.OverrideGraphicSettings.SetProjectionLineColor Method

Sets the projection surface line color.

## Syntax (C#)
```csharp
public OverrideGraphicSettings SetProjectionLineColor(
	Color color
)
```

## Parameters
- **color** (`Autodesk.Revit.DB.Color`) - Value of the projection surface line color for the override. InvalidColorValue means no override is set.

## Returns
Reference to the changed object.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

