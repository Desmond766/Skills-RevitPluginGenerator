---
kind: method
id: M:Autodesk.Revit.DB.FilteredWorksetIterator.IsDone
source: html/32505b45-bd43-2e0f-2447-78be0b359d98.htm
---
# Autodesk.Revit.DB.FilteredWorksetIterator.IsDone Method

Identifies if the iteration has completed.

## Syntax (C#)
```csharp
public virtual bool IsDone()
```

## Returns
True if the iteration has no more matching worksets. False if there are more worksets to be iterated.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The FilteredWorksetCollector that yielded this iterator has been reset by another operation.
 No further iteration is permitted with this iterator.

