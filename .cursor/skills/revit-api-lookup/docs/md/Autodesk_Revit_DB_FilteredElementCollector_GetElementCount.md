---
kind: method
id: M:Autodesk.Revit.DB.FilteredElementCollector.GetElementCount
zh: 筛选、过滤
source: html/886aabfd-ea87-e54c-d108-37d09a44d612.htm
---
# Autodesk.Revit.DB.FilteredElementCollector.GetElementCount Method

**中文**: 筛选、过滤

Gets the number of elements in your current filter.

## Syntax (C#)
```csharp
public int GetElementCount()
```

## Returns
The number of elements

## Remarks
Does not require a filter, if called on a new FilteredElementCollector it will return a count of all the elements.

