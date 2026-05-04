---
kind: method
id: M:Autodesk.Revit.DB.FilteredElementIdIterator.GetCurrent
source: html/4622b4be-e533-d633-26e8-2c4ea5d63742.htm
---
# Autodesk.Revit.DB.FilteredElementIdIterator.GetCurrent Method

The current element id found by the iterator.

## Syntax (C#)
```csharp
public ElementId GetCurrent()
```

## Returns
The element id.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - There are no more element ids in the iterator.
 -or-
 The FilteredElementCollector that yielded this iterator has been reset by another operation.
 No further iteration is permitted with this iterator.
 -or-
 The iterator cannot proceed due to changes made to the Element table in Revit's database (typically, this can be the result of an Element deletion).

