---
kind: method
id: M:Autodesk.Revit.DB.OverrideGraphicSettings.SetSurfaceForegroundPatternId(Autodesk.Revit.DB.ElementId)
source: html/19dfdb3d-548a-0b3a-5569-5dca7ee28bf4.htm
---
# Autodesk.Revit.DB.OverrideGraphicSettings.SetSurfaceForegroundPatternId Method

Sets the ElementId of the surface foreground pattern override.
 The fill pattern must be a drafting pattern.
 A value of InvalidElementId means no override is set.

## Syntax (C#)
```csharp
public OverrideGraphicSettings SetSurfaceForegroundPatternId(
	ElementId fillPatternId
)
```

## Parameters
- **fillPatternId** (`Autodesk.Revit.DB.ElementId`) - Value of the surface foreground fill pattern override.

## Returns
Reference to the changed object.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

