---
kind: method
id: M:Autodesk.Revit.DB.CategoryNameMapIterator.MoveNext
source: html/5fa81fad-1f60-088a-b904-5dfd5bd6de69.htm
---
# Autodesk.Revit.DB.CategoryNameMapIterator.MoveNext Method

Move the iterator one item forward.

## Syntax (C#)
```csharp
public virtual bool MoveNext()
```

## Returns
Returns True if the iterator was successfully moved forward one item and the Current
 property will return a valid item. False will be returned it the iterator has reached the end of
 the map.

## Remarks
MoveNext must be called before the Current property is valid with a new or Reset iterator
 in line with the expected behavior of IEnumerator.

