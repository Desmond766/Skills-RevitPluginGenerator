---
kind: method
id: M:Autodesk.Revit.DB.FilteredElementCollector.GetElementIterator
zh: 筛选、过滤
source: html/7113e21c-90f8-8f58-3b00-407fc1cd56e0.htm
---
# Autodesk.Revit.DB.FilteredElementCollector.GetElementIterator Method

**中文**: 筛选、过滤

Returns an element iterator to the elements passing the filters.

## Syntax (C#)
```csharp
public FilteredElementIterator GetElementIterator()
```

## Remarks
Calling this when you have an active iterator to this same collector will result in the first iterator being
 stopped by this call.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The collector does not have a filter applied. Extraction or iteration of elements is not permitted without a filter.

