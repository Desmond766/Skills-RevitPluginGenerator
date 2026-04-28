---
kind: method
id: M:Autodesk.Revit.DB.ViewPlan.SetViewRange(Autodesk.Revit.DB.PlanViewRange)
zh: 平面视图、平面图
source: html/1c9f1730-e14b-cd30-7062-934fcc47a0ef.htm
---
# Autodesk.Revit.DB.ViewPlan.SetViewRange Method

**中文**: 平面视图、平面图

Sets the view range.

## Syntax (C#)
```csharp
public void SetViewRange(
	PlanViewRange planViewRange
)
```

## Parameters
- **planViewRange** (`Autodesk.Revit.DB.PlanViewRange`) - The view range.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Plan view range is not valid.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

