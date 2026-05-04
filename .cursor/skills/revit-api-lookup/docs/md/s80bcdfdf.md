---
kind: method
id: M:Autodesk.Revit.DB.EdgeArrayArrayIterator.MoveNext
source: html/93cd70c5-b137-a0ab-22fc-abfbc02454e1.htm
---
# Autodesk.Revit.DB.EdgeArrayArrayIterator.MoveNext Method

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

