---
kind: method
id: M:Autodesk.Revit.DB.PlanCircuitSetIterator.MoveNext
source: html/6307450f-1bf5-6cb0-2ff8-6cb846b89611.htm
---
# Autodesk.Revit.DB.PlanCircuitSetIterator.MoveNext Method

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

