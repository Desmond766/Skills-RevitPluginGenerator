---
kind: method
id: M:Autodesk.Revit.DB.WorksharingDisplayGraphicSettings.#ctor(System.Boolean,Autodesk.Revit.DB.Color)
source: html/56c67037-19eb-1243-0fbd-0b8cf84c1576.htm
---
# Autodesk.Revit.DB.WorksharingDisplayGraphicSettings.#ctor Method

Creates a new instance.

## Syntax (C#)
```csharp
public WorksharingDisplayGraphicSettings(
	bool shouldApply,
	Color lineColor
)
```

## Parameters
- **shouldApply** (`System.Boolean`) - True if the settings should be applied, False if they should be set but not applied.
- **lineColor** (`Autodesk.Revit.DB.Color`) - The desired line color, which must be a valid color. Note that the fill
 color is calculated automatically from the line color so it is not advisable
 to use white, black, or shades of grey.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The lineColor argument does not represent a valid color.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

