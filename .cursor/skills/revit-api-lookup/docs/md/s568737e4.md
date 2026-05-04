---
kind: method
id: M:Autodesk.Revit.DB.Electrical.WireSizeSetIterator.MoveNext
source: html/adf9c0ad-e0a5-b31a-f20b-75829614ed50.htm
---
# Autodesk.Revit.DB.Electrical.WireSizeSetIterator.MoveNext Method

Move the iterator one item forward.

## Syntax (C#)
```csharp
public virtual bool MoveNext()
```

## Returns
Returns True if the iterator was successfully moved forward one item and the Current
 property will return a valid item. False will be returned it the iterator has reached the end of
 the set.

## Remarks
MoveNext must be called before the Current property is valid with a new or Reset iterator
 in line with the expected behavior of IEnumerator.

