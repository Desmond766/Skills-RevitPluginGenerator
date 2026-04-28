---
kind: method
id: M:Autodesk.Revit.DB.ReferenceArrayArrayIterator.MoveNext
source: html/8aab817d-d927-57b5-a330-a47a8dab18c3.htm
---
# Autodesk.Revit.DB.ReferenceArrayArrayIterator.MoveNext Method

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

