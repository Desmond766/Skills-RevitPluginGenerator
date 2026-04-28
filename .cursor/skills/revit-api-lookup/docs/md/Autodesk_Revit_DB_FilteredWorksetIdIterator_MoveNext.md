---
kind: method
id: M:Autodesk.Revit.DB.FilteredWorksetIdIterator.MoveNext
source: html/d10232d7-ef6a-a89a-6119-96a4a9ed676d.htm
---
# Autodesk.Revit.DB.FilteredWorksetIdIterator.MoveNext Method

Increments the iterator to the next workset id passing the filter.

## Syntax (C#)
```csharp
public virtual bool MoveNext()
```

## Returns
True if there is another available workset id passing the filter in this iterator.
 False if the iterator has completed all available workset ids.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The FilteredWorksetCollector that yielded this iterator has been reset by another operation.
 No further iteration is permitted with this iterator.

