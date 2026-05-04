---
kind: property
id: P:Autodesk.Revit.DB.SlabShapeVertexArrayIterator.Current
source: html/9e64b1d9-9014-34e7-a552-96405d1f61b1.htm
---
# Autodesk.Revit.DB.SlabShapeVertexArrayIterator.Current Property

Retrieves the item that is the current focus of the iterator.

## Syntax (C#)
```csharp
public virtual Object Current { get; }
```

## Remarks
A new or Reset iterator must have MoveNext called on it before Current will return a valid
 item as per expected behavior of IEnumerator.

