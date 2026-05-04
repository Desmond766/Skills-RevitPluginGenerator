---
kind: method
id: M:Autodesk.Revit.DB.FilteredWorksetIdIterator.IsDone
source: html/a0c362b6-0938-8e56-53ec-47b0f2ee7d57.htm
---
# Autodesk.Revit.DB.FilteredWorksetIdIterator.IsDone Method

Identifies if the iteration has completed.

## Syntax (C#)
```csharp
public virtual bool IsDone()
```

## Returns
True if the iteration has no more matching worksets. False if there are more workset ids to be iterated.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The FilteredWorksetCollector that yielded this iterator has been reset by another operation.
 No further iteration is permitted with this iterator.

