---
kind: method
id: M:Autodesk.Revit.DB.ReferenceArrayIterator.MoveNext
source: html/64716789-2423-d7f4-70d5-68ab5c0b9447.htm
---
# Autodesk.Revit.DB.ReferenceArrayIterator.MoveNext Method

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

