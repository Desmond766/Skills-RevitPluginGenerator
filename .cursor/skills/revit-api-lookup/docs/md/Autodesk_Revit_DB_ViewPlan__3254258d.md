---
kind: type
id: T:Autodesk.Revit.DB.ViewPlan
zh: 平面视图、平面图
source: html/0520580a-74ec-ed8c-35ea-5274c42276a3.htm
---
# Autodesk.Revit.DB.ViewPlan

**中文**: 平面视图、平面图

Represents floor plan, area plan, ceiling plan, and structural plan views in Revit.

## Syntax (C#)
```csharp
public class ViewPlan : View
```

## Remarks
In a plan view, the model is viewed as if cut by the cut plane and viewed from above, looking down.
 In ceiling plan views and structural plan views which look up, the model is viewed as if cut by
 the cut plane, and viewed as if looking down at a mirror.

