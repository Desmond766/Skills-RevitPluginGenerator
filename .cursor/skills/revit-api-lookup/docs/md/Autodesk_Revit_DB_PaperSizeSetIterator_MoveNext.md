---
kind: method
id: M:Autodesk.Revit.DB.PaperSizeSetIterator.MoveNext
source: html/47a5a621-7f20-dc97-0787-5c44ee3bd4a7.htm
---
# Autodesk.Revit.DB.PaperSizeSetIterator.MoveNext Method

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

