---
kind: method
id: M:Autodesk.Revit.DB.FilteredElementCollector.ToElementIds
zh: 筛选、过滤
source: html/bfb8c8a2-aa2f-b1bc-7d57-7e3f7d39fcae.htm
---
# Autodesk.Revit.DB.FilteredElementCollector.ToElementIds Method

**中文**: 筛选、过滤

Returns the complete set of element ids that pass the filter(s).

## Syntax (C#)
```csharp
public ICollection<ElementId> ToElementIds()
```

## Returns
The complete set of element ids.

## Remarks
This will reset the collector to the beginning and extract all elements that pass the applied filter(s).
 If you have an active iterator to this same collector it will be stopped by this call.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The collector does not have a filter applied. Extraction or iteration of elements is not permitted without a filter.

