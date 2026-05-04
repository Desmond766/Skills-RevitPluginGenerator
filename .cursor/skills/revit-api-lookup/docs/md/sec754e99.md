---
kind: method
id: M:Autodesk.Revit.DB.FilteredElementCollector.ToElements
zh: 筛选、过滤
source: html/732b4a0d-62d8-b86d-120b-8ea3d9713b34.htm
---
# Autodesk.Revit.DB.FilteredElementCollector.ToElements Method

**中文**: 筛选、过滤

Returns the complete set of elements that pass the filter(s).

## Syntax (C#)
```csharp
public IList<Element> ToElements()
```

## Returns
The complete set of element ids.

## Remarks
This will reset the collector to the beginning and extract all elements that pass the applied filter(s).
 If you have an active iterator to this same collector it will be stopped by this call.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The collector does not have a filter applied. Extraction or iteration of elements is not permitted without a filter.

