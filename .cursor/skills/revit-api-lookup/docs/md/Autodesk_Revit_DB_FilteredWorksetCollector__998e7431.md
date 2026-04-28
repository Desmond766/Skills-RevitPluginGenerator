---
kind: type
id: T:Autodesk.Revit.DB.FilteredWorksetCollector
source: html/30e91d82-33a2-2561-db2a-28098a96b3ec.htm
---
# Autodesk.Revit.DB.FilteredWorksetCollector

This class is used to search, filter and iterate through a set of worksets.

## Syntax (C#)
```csharp
public class FilteredWorksetCollector : IEnumerable<Workset>, 
	IDisposable
```

## Remarks
Developers can assign a condition to filter the worksets that are returned.
 If no condition is applied, it attempts to access all the worksets in the document. The collector will reset if you call another method to
 extract worksets. Thus, if you have previously obtained an iterator, it will be stopped and traverse no more
 worksets if you call another method to extract worksets.

