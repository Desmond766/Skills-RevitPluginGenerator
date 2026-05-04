---
kind: method
id: M:Autodesk.Revit.DB.FilteredWorksetCollector.GetWorksetIterator
source: html/70daa82a-8893-bc5c-fa4a-85737f5c261a.htm
---
# Autodesk.Revit.DB.FilteredWorksetCollector.GetWorksetIterator Method

Returns a FilteredWorksetIterator to the worksets passing the current filter.

## Syntax (C#)
```csharp
public FilteredWorksetIterator GetWorksetIterator()
```

## Remarks
Calling this when you have an active iterator to this same collector will result in the first iterator being
 stopped by this call.

