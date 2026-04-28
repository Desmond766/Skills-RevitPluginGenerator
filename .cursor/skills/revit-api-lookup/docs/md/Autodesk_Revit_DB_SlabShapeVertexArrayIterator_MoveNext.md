---
kind: method
id: M:Autodesk.Revit.DB.SlabShapeVertexArrayIterator.MoveNext
source: html/42812cb2-02e9-7767-9110-2080e725a01c.htm
---
# Autodesk.Revit.DB.SlabShapeVertexArrayIterator.MoveNext Method

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

