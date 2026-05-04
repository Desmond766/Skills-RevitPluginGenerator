---
kind: method
id: M:Autodesk.Revit.DB.FilteredElementIterator.MoveNext
source: html/907426ed-db06-8056-3ca2-bff26f2a052b.htm
---
# Autodesk.Revit.DB.FilteredElementIterator.MoveNext Method

Increments the iterator to the next element passing the filter.

## Syntax (C#)
```csharp
public virtual bool MoveNext()
```

## Returns
True if there is another available element passing the filter in this iterator.
 False if the iterator has completed all available elements.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The FilteredElementCollector that yielded this iterator has been reset by another operation.
 No further iteration is permitted with this iterator.
 -or-
 The iterator cannot proceed due to changes made to the Element table in Revit's database (typically,
 This can be the result of an Element deletion).

