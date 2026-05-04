---
kind: property
id: P:Autodesk.Revit.DB.FaceArrayIterator.Current
source: html/95a1780e-3a8c-d5a4-1e63-0846ee30e3e0.htm
---
# Autodesk.Revit.DB.FaceArrayIterator.Current Property

Retrieves the item that is the current focus of the iterator.

## Syntax (C#)
```csharp
public virtual Object Current { get; }
```

## Remarks
A new or Reset iterator must have MoveNext called on it before Current will return a valid
 item as per expected behavior of IEnumerator.

