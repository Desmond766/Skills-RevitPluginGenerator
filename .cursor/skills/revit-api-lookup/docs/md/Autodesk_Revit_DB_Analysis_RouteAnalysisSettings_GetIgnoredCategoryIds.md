---
kind: method
id: M:Autodesk.Revit.DB.Analysis.RouteAnalysisSettings.GetIgnoredCategoryIds
source: html/e4115866-1e15-9b46-d783-7fc5786e88c5.htm
---
# Autodesk.Revit.DB.Analysis.RouteAnalysisSettings.GetIgnoredCategoryIds Method

Returns ElementIds for Category elements which are ignored (not taken into account) route calculation.
 To enable ignoring of these categories, EnableIgnoredCategoryIds must be set to true.
 If an ignored category has sub-categories, then the sub-categories will be ignored as well.

## Syntax (C#)
```csharp
public ICollection<ElementId> GetIgnoredCategoryIds()
```

## Returns
The ids of Categories which are ignored by route calculation. By default, the set contains the Doors Category.

