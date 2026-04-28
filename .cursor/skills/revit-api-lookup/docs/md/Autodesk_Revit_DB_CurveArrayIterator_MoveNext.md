---
kind: method
id: M:Autodesk.Revit.DB.CurveArrayIterator.MoveNext
source: html/a99662a1-b07a-d081-caea-6b881d0ae0ee.htm
---
# Autodesk.Revit.DB.CurveArrayIterator.MoveNext Method

Move the iterator one item forward.

## Syntax (C#)
```csharp
public virtual bool MoveNext()
```

## Returns
Returns True if the iterator was successfully moved forward one item and the Current
 property will return a valid item. False will be returned it the iterator has reached the end of
 the array.

## Remarks
MoveNext must be called before the Current property is valid with a new or Reset iterator
 in line with the expected behavior of IEnumerator.

