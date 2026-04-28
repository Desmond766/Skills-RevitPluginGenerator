---
kind: method
id: M:Autodesk.Revit.DB.FilteredWorksetCollector.ToWorksets
source: html/32db1fdd-6679-1e33-d3d2-9057b6a26e91.htm
---
# Autodesk.Revit.DB.FilteredWorksetCollector.ToWorksets Method

Returns the complete set of worksets that pass the filter(s).

## Syntax (C#)
```csharp
public IList<Workset> ToWorksets()
```

## Returns
The complete array of worksets.

## Remarks
This will reset the collector to the beginning and extract all worksets that pass the applied filter(s).
 If you have an active iterator to this same collector it will be stopped by this call.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The collector does not have a filter applied. Extraction or iteration of worksets is not permitted without a filter.

