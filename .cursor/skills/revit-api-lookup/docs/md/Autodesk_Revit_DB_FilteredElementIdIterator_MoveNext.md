---
kind: method
id: M:Autodesk.Revit.DB.FilteredElementIdIterator.MoveNext
source: html/ef73f3f0-2049-2ebf-fccd-84a2c85949b7.htm
---
# Autodesk.Revit.DB.FilteredElementIdIterator.MoveNext Method

Increments the iterator to the next element id passing the filter.

## Syntax (C#)
```csharp
public virtual bool MoveNext()
```

## Returns
True if there is another available element id passing the filter in this iterator.
 False if the iterator has completed all available element ids.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The FilteredElementCollector that yielded this iterator has been reset by another operation.
 No further iteration is permitted with this iterator.
 -or-
 The iterator cannot proceed due to changes made to the Element table in Revit's database (typically, this can be the result of an Element deletion).

