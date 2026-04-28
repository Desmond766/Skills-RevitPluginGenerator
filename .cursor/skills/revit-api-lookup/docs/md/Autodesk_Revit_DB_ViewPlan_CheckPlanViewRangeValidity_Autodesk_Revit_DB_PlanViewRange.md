---
kind: method
id: M:Autodesk.Revit.DB.ViewPlan.CheckPlanViewRangeValidity(Autodesk.Revit.DB.PlanViewRange)
zh: 平面视图、平面图
source: html/2a4f0854-2b24-1f86-423c-0e4ea4ddc9f7.htm
---
# Autodesk.Revit.DB.ViewPlan.CheckPlanViewRangeValidity Method

**中文**: 平面视图、平面图

Checks if the plan view range is valid.

## Syntax (C#)
```csharp
public IList<PlanViewRangeError> CheckPlanViewRangeValidity(
	PlanViewRange planViewRange
)
```

## Parameters
- **planViewRange** (`Autodesk.Revit.DB.PlanViewRange`) - The view range to validate.

## Returns
List of enums describing any errors in the plan view range.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

