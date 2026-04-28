---
kind: method
id: M:Autodesk.Revit.DB.FilteredElementCollector.GetElementIdIterator
zh: 筛选、过滤
source: html/0b1cdbeb-21ce-a4c5-6cae-253595818085.htm
---
# Autodesk.Revit.DB.FilteredElementCollector.GetElementIdIterator Method

**中文**: 筛选、过滤

Returns an element id iterator to the elements passing the filters.

## Syntax (C#)
```csharp
public FilteredElementIdIterator GetElementIdIterator()
```

## Remarks
Calling this when you have an active iterator to this same collector will result in the first iterator being
 stopped by this call.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The collector does not have a filter applied. Extraction or iteration of elements is not permitted without a filter.

