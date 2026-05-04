---
kind: method
id: M:Autodesk.Revit.DB.FilteredWorksetCollector.FirstWorkset
source: html/2bec8a78-762f-3c54-8f9d-3df46e1d133b.htm
---
# Autodesk.Revit.DB.FilteredWorksetCollector.FirstWorkset Method

Returns the first workset to pass the filter(s).

## Syntax (C#)
```csharp
public Workset FirstWorkset()
```

## Returns
The first workset.

## Remarks
This will reset the collector to the beginning and find the first workset that passes the applied filter(s).
 If you have an active iterator to this same collector it will be stopped by this call.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The collector does not have a filter applied. Extraction or iteration of worksets is not permitted without a filter.

