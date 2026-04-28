---
kind: method
id: M:Autodesk.Revit.DB.SymbolicCurveArrayIterator.MoveNext
source: html/a5a86a50-f35a-c826-a7a6-f6089f0de9ae.htm
---
# Autodesk.Revit.DB.SymbolicCurveArrayIterator.MoveNext Method

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

