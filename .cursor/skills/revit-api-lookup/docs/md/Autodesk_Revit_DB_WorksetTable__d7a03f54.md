---
kind: type
id: T:Autodesk.Revit.DB.WorksetTable
source: html/9ffa5fc8-e6a5-17d6-590e-8ecbfd7b85fb.htm
---
# Autodesk.Revit.DB.WorksetTable

A table containing references to all the worksets contained in a document.

## Syntax (C#)
```csharp
public class WorksetTable : IDisposable
```

## Remarks
There is one WorksetTable for each document.
 There will be at least one default workset in the table, even if worksharing has not been enabled in the document.

