---
kind: method
id: M:Autodesk.Revit.DB.CurveByPointsArrayIterator.MoveNext
source: html/49676547-a725-5a96-1bd7-3bd1bd48de0c.htm
---
# Autodesk.Revit.DB.CurveByPointsArrayIterator.MoveNext Method

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

