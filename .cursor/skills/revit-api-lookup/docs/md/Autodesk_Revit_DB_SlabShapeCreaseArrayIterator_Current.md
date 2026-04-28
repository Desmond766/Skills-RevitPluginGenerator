---
kind: property
id: P:Autodesk.Revit.DB.SlabShapeCreaseArrayIterator.Current
source: html/861583cb-ab4f-5cfb-43bf-b3184d13755d.htm
---
# Autodesk.Revit.DB.SlabShapeCreaseArrayIterator.Current Property

Retrieves the item that is the current focus of the iterator.

## Syntax (C#)
```csharp
public virtual Object Current { get; }
```

## Remarks
A new or Reset iterator must have MoveNext called on it before Current will return a valid
 item as per expected behavior of IEnumerator.

