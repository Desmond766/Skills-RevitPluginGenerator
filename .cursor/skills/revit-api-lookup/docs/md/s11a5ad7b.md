---
kind: method
id: M:Autodesk.Revit.DB.FilteredWorksetIterator.GetCurrent
source: html/f0ca7ab5-3cfb-3bdb-f23e-08aba7fdd9b3.htm
---
# Autodesk.Revit.DB.FilteredWorksetIterator.GetCurrent Method

The current workset found by the iterator.

## Syntax (C#)
```csharp
public Workset GetCurrent()
```

## Returns
The workset.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - There are no more worksets in the iterator.
 -or-
 The FilteredWorksetCollector that yielded this iterator has been reset by another operation.
 No further iteration is permitted with this iterator.

