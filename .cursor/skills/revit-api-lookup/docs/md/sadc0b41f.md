---
kind: method
id: M:Autodesk.Revit.DB.FilteredElementCollector.OfCategory(Autodesk.Revit.DB.BuiltInCategory)
zh: 筛选、过滤
source: html/c3523c35-4a07-9723-3c28-de3cc47b2ad0.htm
---
# Autodesk.Revit.DB.FilteredElementCollector.OfCategory Method

**中文**: 筛选、过滤

Applies an ElementCategoryFilter to the collector.

## Syntax (C#)
```csharp
public FilteredElementCollector OfCategory(
	BuiltInCategory category
)
```

## Parameters
- **category** (`Autodesk.Revit.DB.BuiltInCategory`) - The category.

## Returns
This collector.

## Remarks
Only elements of this category id will pass the collector.

