---
kind: method
id: M:Autodesk.Revit.DB.Mechanical.SpaceSetIterator.MoveNext
source: html/1d989890-99d2-f985-4109-a7cb4e0f6c5d.htm
---
# Autodesk.Revit.DB.Mechanical.SpaceSetIterator.MoveNext Method

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

