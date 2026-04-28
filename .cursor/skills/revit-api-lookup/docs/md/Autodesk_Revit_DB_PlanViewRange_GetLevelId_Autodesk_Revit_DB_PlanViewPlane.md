---
kind: method
id: M:Autodesk.Revit.DB.PlanViewRange.GetLevelId(Autodesk.Revit.DB.PlanViewPlane)
source: html/9c56cd0b-bd1b-47f6-b669-5870b2966c1f.htm
---
# Autodesk.Revit.DB.PlanViewRange.GetLevelId Method

Get the element id of the level for a View Depth plane

## Syntax (C#)
```csharp
public ElementId GetLevelId(
	PlanViewPlane planViewPlane
)
```

## Parameters
- **planViewPlane** (`Autodesk.Revit.DB.PlanViewPlane`) - The plane whose level will be returned

## Returns
Id of the level

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

