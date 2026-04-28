---
kind: method
id: M:Autodesk.Revit.DB.PanelTypeSetIterator.MoveNext
source: html/e0152d76-3cda-6a34-a31b-5094ed9bb374.htm
---
# Autodesk.Revit.DB.PanelTypeSetIterator.MoveNext Method

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

