---
kind: method
id: M:Autodesk.Revit.DB.OverrideGraphicSettings.SetSurfaceBackgroundPatternId(Autodesk.Revit.DB.ElementId)
source: html/3decba62-28ce-5f07-0d78-447de6641932.htm
---
# Autodesk.Revit.DB.OverrideGraphicSettings.SetSurfaceBackgroundPatternId Method

Sets the ElementId of the surface background pattern override.
 The fill pattern must be a drafting pattern.
 A value of InvalidElementId means no override is set.

## Syntax (C#)
```csharp
public OverrideGraphicSettings SetSurfaceBackgroundPatternId(
	ElementId fillPatternId
)
```

## Parameters
- **fillPatternId** (`Autodesk.Revit.DB.ElementId`) - Value of the surface background fill pattern override.

## Returns
Reference to the changed object.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

