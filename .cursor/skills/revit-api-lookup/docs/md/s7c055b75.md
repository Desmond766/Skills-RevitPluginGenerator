---
kind: method
id: M:Autodesk.Revit.DB.CombinableElementArrayIterator.MoveNext
source: html/40613596-ce3f-eedb-3e3f-0028bd682be8.htm
---
# Autodesk.Revit.DB.CombinableElementArrayIterator.MoveNext Method

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

