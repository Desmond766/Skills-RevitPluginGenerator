---
kind: method
id: M:Autodesk.Revit.DB.Analysis.RouteAnalysisSettings.GetExcludedCategoryIds
source: html/d1cf8070-f971-feb0-df35-649982e68bc6.htm
---
# Autodesk.Revit.DB.Analysis.RouteAnalysisSettings.GetExcludedCategoryIds Method

Returns ElementIds for Category elements which are excluded (not taken into account) by route calculation.
 These categories are always excluded, regardless of the EnableIgnoredCategoryIds value.
 If an excluded category has sub-categories, then the sub-categories will be excluded as well.

## Syntax (C#)
```csharp
public ICollection<ElementId> GetExcludedCategoryIds()
```

## Returns
The ids of Categories which are excluded by route calculation.

