---
kind: method
id: M:Autodesk.Revit.DB.FilteredWorksetCollector.WherePasses(Autodesk.Revit.DB.WorksetFilter)
source: html/16a05b73-719f-6326-7db1-bbc42593d754.htm
---
# Autodesk.Revit.DB.FilteredWorksetCollector.WherePasses Method

Applies a workset filter to the collector.

## Syntax (C#)
```csharp
public FilteredWorksetCollector WherePasses(
	WorksetFilter filter
)
```

## Parameters
- **filter** (`Autodesk.Revit.DB.WorksetFilter`) - The workset filter.

## Returns
A handle to this collector. This is the same collector that has just been modified, returned
 so you can chain multiple calls together in one line.

## Remarks
The filter will be added as an additional condition that all filtered worksets must pass.
 If you have an active iterator to this collector it will be stopped by this call.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

