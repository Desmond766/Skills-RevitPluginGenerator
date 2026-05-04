---
kind: method
id: M:Autodesk.Revit.DB.View.SupportedColorFillCategoryIds
zh: 视图
source: html/84197491-81de-0713-06bf-fa7073419485.htm
---
# Autodesk.Revit.DB.View.SupportedColorFillCategoryIds Method

**中文**: 视图

Returns collection of all category ids that correspond to elements that can potentially be colored in this view
 according to a color fill scheme. The set may be different depending on the view type.

## Syntax (C#)
```csharp
public ICollection<ElementId> SupportedColorFillCategoryIds()
```

## Remarks
All of the possible categories are OST_Rooms, OST_HVAC_Zones, OST_MEPSpaces, OST_Areas, OST_DuctCurves and OST_PipeCurves.

