---
kind: method
id: M:Autodesk.Revit.DB.FilteredElementCollector.FirstElement
zh: 筛选、过滤
source: html/c8c1cae0-4ac8-a309-e915-6d491137d47e.htm
---
# Autodesk.Revit.DB.FilteredElementCollector.FirstElement Method

**中文**: 筛选、过滤

Returns the first element to pass the filter(s).

## Syntax (C#)
```csharp
public Element FirstElement()
```

## Returns
The first element.

## Remarks
This will reset the collector to the beginning and find the first element that passes the applied filter(s).
 If you have an active iterator to this same collector it will be stopped by this call.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The collector does not have a filter applied. Extraction or iteration of elements is not permitted without a filter.

