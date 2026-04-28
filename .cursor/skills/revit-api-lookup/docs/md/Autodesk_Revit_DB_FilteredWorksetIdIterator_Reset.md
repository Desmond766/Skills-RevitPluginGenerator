---
kind: method
id: M:Autodesk.Revit.DB.FilteredWorksetIdIterator.Reset
source: html/56c9dbc5-0b6b-da28-c3d7-9ff4c72fdfbb.htm
---
# Autodesk.Revit.DB.FilteredWorksetIdIterator.Reset Method

Resets the iterator to the beginning.

## Syntax (C#)
```csharp
public virtual void Reset()
```

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The FilteredWorksetCollector that yielded this iterator has been reset by another operation.
 No further iteration is permitted with this iterator.

