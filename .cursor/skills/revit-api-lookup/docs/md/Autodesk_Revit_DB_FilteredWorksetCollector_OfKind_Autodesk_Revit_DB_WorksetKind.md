---
kind: method
id: M:Autodesk.Revit.DB.FilteredWorksetCollector.OfKind(Autodesk.Revit.DB.WorksetKind)
source: html/98be6e5a-6238-c2bd-0fb5-aab53ab6d582.htm
---
# Autodesk.Revit.DB.FilteredWorksetCollector.OfKind Method

Applies a WorksetKindFilter to the collector.

## Syntax (C#)
```csharp
public FilteredWorksetCollector OfKind(
	WorksetKind worksetKind
)
```

## Parameters
- **worksetKind** (`Autodesk.Revit.DB.WorksetKind`) - The WorksetKind of the workset.

## Returns
A handle to this collector. This is the same collector that has just been modified, returned
 so you can chain multiple calls together in one line.

## Remarks
Only worksets whose WorksetKind is an exact match to the input WorksetKind will pass the collector.
 If you have an active iterator to this collector it will be stopped by this call.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

