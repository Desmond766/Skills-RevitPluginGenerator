---
kind: method
id: M:Autodesk.Revit.DB.Electrical.CorrectionFactorSetIterator.MoveNext
source: html/5d4a27d4-bd70-2679-79da-e423c330ca5e.htm
---
# Autodesk.Revit.DB.Electrical.CorrectionFactorSetIterator.MoveNext Method

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

