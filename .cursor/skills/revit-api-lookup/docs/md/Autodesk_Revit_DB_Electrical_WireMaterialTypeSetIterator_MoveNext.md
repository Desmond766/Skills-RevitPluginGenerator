---
kind: method
id: M:Autodesk.Revit.DB.Electrical.WireMaterialTypeSetIterator.MoveNext
source: html/9c83a6a3-7d2e-1e96-2fc7-04c35ff75621.htm
---
# Autodesk.Revit.DB.Electrical.WireMaterialTypeSetIterator.MoveNext Method

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

