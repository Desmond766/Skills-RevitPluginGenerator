---
kind: method
id: M:Autodesk.Revit.DB.OverrideGraphicSettings.SetCutLinePatternId(Autodesk.Revit.DB.ElementId)
source: html/21855de7-46e1-4899-3b79-b8452cbe99ca.htm
---
# Autodesk.Revit.DB.OverrideGraphicSettings.SetCutLinePatternId Method

Sets the ElementId of the cut surface line pattern.

## Syntax (C#)
```csharp
public OverrideGraphicSettings SetCutLinePatternId(
	ElementId linePatternId
)
```

## Parameters
- **linePatternId** (`Autodesk.Revit.DB.ElementId`) - ElementId of the cut surface line pattern for the override. InvalidElementId means no override is set.

## Returns
Reference to the changed object.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

