---
kind: method
id: M:Autodesk.Revit.DB.ModelCurveArrArrayIterator.MoveNext
source: html/97cd10d8-0bac-1cc5-1283-681c6fe4e03d.htm
---
# Autodesk.Revit.DB.ModelCurveArrArrayIterator.MoveNext Method

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

