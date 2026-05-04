---
kind: method
id: M:Autodesk.Revit.DB.PlanTopologySetIterator.MoveNext
source: html/6bc47a6e-83a6-bc35-cb5d-eb85dd5673e3.htm
---
# Autodesk.Revit.DB.PlanTopologySetIterator.MoveNext Method

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

