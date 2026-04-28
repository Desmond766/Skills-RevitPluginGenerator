---
kind: property
id: P:Autodesk.Revit.DB.ReferenceArrayIterator.Current
source: html/88cdc3bf-a26f-be67-5f13-1d5d73b2d5f0.htm
---
# Autodesk.Revit.DB.ReferenceArrayIterator.Current Property

Retrieves the item that is the current focus of the iterator.

## Syntax (C#)
```csharp
public virtual Object Current { get; }
```

## Remarks
A new or Reset iterator must have MoveNext called on it before Current will return a valid
 item as per expected behavior of IEnumerator.

