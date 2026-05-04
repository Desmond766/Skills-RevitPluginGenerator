---
kind: method
id: M:Autodesk.Revit.DB.SunAndShadowSettings.IsGroundPlaneLevelValid(Autodesk.Revit.DB.ElementId)
source: html/55c05757-98af-05dd-24c3-9793d595af51.htm
---
# Autodesk.Revit.DB.SunAndShadowSettings.IsGroundPlaneLevelValid Method

Checks whether the element represents a valid Ground Plane level.

## Syntax (C#)
```csharp
public bool IsGroundPlaneLevelValid(
	ElementId levelId
)
```

## Parameters
- **levelId** (`Autodesk.Revit.DB.ElementId`) - Level element id.

## Returns
True if the element is a valid Ground Plane Level, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

