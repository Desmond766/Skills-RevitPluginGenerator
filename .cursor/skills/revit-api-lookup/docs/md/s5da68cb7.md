---
kind: method
id: M:Autodesk.Revit.DB.PlanViewRange.SetLevelId(Autodesk.Revit.DB.PlanViewPlane,Autodesk.Revit.DB.ElementId)
source: html/ef2d4027-3b09-f62e-5507-2d39615b8b4a.htm
---
# Autodesk.Revit.DB.PlanViewRange.SetLevelId Method

Set the level for a View Depth plane

## Syntax (C#)
```csharp
public void SetLevelId(
	PlanViewPlane planViewPlane,
	ElementId id
)
```

## Parameters
- **planViewPlane** (`Autodesk.Revit.DB.PlanViewPlane`) - The View Depth plane
- **id** (`Autodesk.Revit.DB.ElementId`) - Id of the level

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

