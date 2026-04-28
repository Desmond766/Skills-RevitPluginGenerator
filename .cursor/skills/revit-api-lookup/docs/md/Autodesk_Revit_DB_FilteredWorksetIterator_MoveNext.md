---
kind: method
id: M:Autodesk.Revit.DB.FilteredWorksetIterator.MoveNext
source: html/b10feb43-f688-e7c5-97cc-5539cec84a9f.htm
---
# Autodesk.Revit.DB.FilteredWorksetIterator.MoveNext Method

Increments the iterator to the next workset passing the filter.

## Syntax (C#)
```csharp
public virtual bool MoveNext()
```

## Returns
True if there is another available workset passing the filter in this iterator.
 False if the iterator has completed all available worksets.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The FilteredWorksetCollector that yielded this iterator has been reset by another operation.
 No further iteration is permitted with this iterator.

