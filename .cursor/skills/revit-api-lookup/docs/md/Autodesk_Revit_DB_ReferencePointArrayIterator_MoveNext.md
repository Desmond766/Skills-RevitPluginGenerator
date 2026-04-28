---
kind: method
id: M:Autodesk.Revit.DB.ReferencePointArrayIterator.MoveNext
source: html/de0a3699-e25b-9e99-05d4-5e32e4dae96d.htm
---
# Autodesk.Revit.DB.ReferencePointArrayIterator.MoveNext Method

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

