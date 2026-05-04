---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarContainerIterator.MoveNext
source: html/ecb114df-7832-3d06-4db3-35403ce3cbca.htm
---
# Autodesk.Revit.DB.Structure.RebarContainerIterator.MoveNext Method

Increments the iterator to the next item.

## Syntax (C#)
```csharp
public virtual bool MoveNext()
```

## Returns
True if there is a next available item in this iterator.
 False if the iterator has completed all available items.

## Remarks
After an enumerator is created or after the Reset method is called, an enumerator is positioned before the first element of the collection,
 and the first call to the MoveNext method moves the enumerator over the first element of the collection.

