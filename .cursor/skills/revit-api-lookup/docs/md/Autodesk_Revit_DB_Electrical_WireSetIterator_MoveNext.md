---
kind: method
id: M:Autodesk.Revit.DB.Electrical.WireSetIterator.MoveNext
source: html/5d315781-cc2b-a234-3386-b23adb4b880b.htm
---
# Autodesk.Revit.DB.Electrical.WireSetIterator.MoveNext Method

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

