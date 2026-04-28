---
kind: method
id: M:Autodesk.Revit.DB.FilteredWorksetCollector.FirstWorksetId
source: html/dc790ba3-0477-1e2f-cc76-1ee64747d5a8.htm
---
# Autodesk.Revit.DB.FilteredWorksetCollector.FirstWorksetId Method

Returns the id of the first workset to pass the filter(s).

## Syntax (C#)
```csharp
public WorksetId FirstWorksetId()
```

## Returns
The first workset id.

## Remarks
This will reset the collector to the beginning and find the first workset that passes the applied filter(s).
 If you have an active iterator to this same collector it will be stopped by this call.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The collector does not have a filter applied. Extraction or iteration of worksets is not permitted without a filter.

