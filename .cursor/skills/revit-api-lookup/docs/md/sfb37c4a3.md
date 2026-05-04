---
kind: method
id: M:Autodesk.Revit.DB.OverrideGraphicSettings.SetCutLineColor(Autodesk.Revit.DB.Color)
source: html/63294eef-7442-5184-ac64-9a0993d8f5a9.htm
---
# Autodesk.Revit.DB.OverrideGraphicSettings.SetCutLineColor Method

Sets the cut surface line color.

## Syntax (C#)
```csharp
public OverrideGraphicSettings SetCutLineColor(
	Color color
)
```

## Parameters
- **color** (`Autodesk.Revit.DB.Color`) - Value of the cut surface line color for the override. InvalidColorValue means no override is set.

## Returns
Reference to the changed object.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

