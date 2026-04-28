---
kind: method
id: M:Autodesk.Revit.DB.Viewport.SetBoxCenter(Autodesk.Revit.DB.XYZ)
source: html/71734b96-6582-e6c5-674a-e6c092ced0f2.htm
---
# Autodesk.Revit.DB.Viewport.SetBoxCenter Method

Moves this viewport so that the center of the box outline (excluding the viewport label) is at a given point.

## Syntax (C#)
```csharp
public void SetBoxCenter(
	XYZ newCenterPoint
)
```

## Parameters
- **newCenterPoint** (`Autodesk.Revit.DB.XYZ`) - The desired center for the box outline.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The viewport is not on a sheet.

