---
kind: method
id: M:Autodesk.Revit.DB.FilteredWorksetCollector.ToWorksetIds
source: html/1760f71f-d481-5d97-beb8-cfbc96ea2db5.htm
---
# Autodesk.Revit.DB.FilteredWorksetCollector.ToWorksetIds Method

Returns the complete set of workset ids that pass the filter(s).

## Syntax (C#)
```csharp
public ICollection<WorksetId> ToWorksetIds()
```

## Returns
The complete set of workset ids.

## Remarks
This will reset the collector to the beginning and extract all worksets that pass the applied filter(s).
 If you have an active iterator to this same collector it will be stopped by this call.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The collector does not have a filter applied. Extraction or iteration of worksets is not permitted without a filter.

