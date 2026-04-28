---
kind: method
id: M:Autodesk.Revit.DB.CurveLoopIterator.MoveNext
source: html/b9edfa1f-f964-f6d6-f39f-b05257841e20.htm
---
# Autodesk.Revit.DB.CurveLoopIterator.MoveNext Method

Increments the iterator to the next item.

## Syntax (C#)
```csharp
public virtual bool MoveNext()
```

## Returns
True if there is a next available item in this iterator.
 False if the iterator has completed all available items.

## Remarks
After an enumerator is created or after the Reset method is called, an enumerator is positioned before the first element of the collection,
 and the first call to the MoveNext method moves the enumerator over the first element of the collection.

