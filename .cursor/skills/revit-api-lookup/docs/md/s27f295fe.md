---
kind: method
id: M:Autodesk.Revit.DB.FilteredWorksetIdIterator.GetCurrent
source: html/ef99d539-5039-bf16-ee24-91daef82355d.htm
---
# Autodesk.Revit.DB.FilteredWorksetIdIterator.GetCurrent Method

The current workset id found by the iterator.

## Syntax (C#)
```csharp
public WorksetId GetCurrent()
```

## Returns
The workset id.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - There are no more workset ids in the iterator.
 -or-
 The FilteredWorksetCollector that yielded this iterator has been reset by another operation.
 No further iteration is permitted with this iterator.

