---
kind: method
id: M:Autodesk.Revit.DB.FilteredElementIterator.GetCurrent
source: html/05e73775-334c-a708-7493-a9489ef03e45.htm
---
# Autodesk.Revit.DB.FilteredElementIterator.GetCurrent Method

The current element found by the iterator.

## Syntax (C#)
```csharp
public Element GetCurrent()
```

## Returns
The element.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - There are no more element ids in the iterator.
 -or-
 The FilteredElementCollector that yielded this iterator has been reset by another operation.
 No further iteration is permitted with this iterator.
 -or-
 The iterator cannot proceed due to changes made to the Element table in Revit's database (typically,
 This can be the result of an Element deletion).

