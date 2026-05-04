---
kind: method
id: M:Autodesk.Revit.DB.FilteredWorksetIterator.Reset
source: html/b1df2f56-3adc-6562-9d88-834ffc205e3d.htm
---
# Autodesk.Revit.DB.FilteredWorksetIterator.Reset Method

Resets the iterator to the beginning.

## Syntax (C#)
```csharp
public virtual void Reset()
```

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The FilteredWorksetCollector that yielded this iterator has been reset by another operation.
 No further iteration is permitted with this iterator.

