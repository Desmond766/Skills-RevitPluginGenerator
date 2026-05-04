---
kind: method
id: M:Autodesk.Revit.DB.FilteredWorksetCollector.GetWorksetIdIterator
source: html/21ebbe3f-f9d2-0030-5d99-ebb43be66b2d.htm
---
# Autodesk.Revit.DB.FilteredWorksetCollector.GetWorksetIdIterator Method

Returns a FilteredWorksetIdIterator to the worksets passing the current filter.

## Syntax (C#)
```csharp
public FilteredWorksetIdIterator GetWorksetIdIterator()
```

## Remarks
Calling this when you have an active iterator to this same collector will result in the first iterator being
 stopped by this call.

