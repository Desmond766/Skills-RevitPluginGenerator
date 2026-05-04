---
kind: property
id: P:Autodesk.Revit.DB.VertexIndexPairArrayIterator.Current
source: html/b4de5f6f-5ad5-25ca-57ec-449d9cfdb978.htm
---
# Autodesk.Revit.DB.VertexIndexPairArrayIterator.Current Property

Retrieves the item that is the current focus of the iterator.

## Syntax (C#)
```csharp
public virtual Object Current { get; }
```

## Remarks
A new or Reset iterator must have MoveNext called on it before Current will return a valid
 item as per expected behavior of IEnumerator.

