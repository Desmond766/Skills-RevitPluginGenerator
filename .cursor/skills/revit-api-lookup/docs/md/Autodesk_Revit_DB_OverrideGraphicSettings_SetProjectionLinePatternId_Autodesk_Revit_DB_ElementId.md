---
kind: method
id: M:Autodesk.Revit.DB.OverrideGraphicSettings.SetProjectionLinePatternId(Autodesk.Revit.DB.ElementId)
source: html/4a2e6314-ae79-f1bb-3727-9ae8bc815b6f.htm
---
# Autodesk.Revit.DB.OverrideGraphicSettings.SetProjectionLinePatternId Method

Sets the ElementId of the projection surface line pattern.

## Syntax (C#)
```csharp
public OverrideGraphicSettings SetProjectionLinePatternId(
	ElementId linePatternId
)
```

## Parameters
- **linePatternId** (`Autodesk.Revit.DB.ElementId`) - ElementId of the projection surface line pattern for the override. InvalidElementId means no override is set.

## Returns
Reference to the changed object.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

