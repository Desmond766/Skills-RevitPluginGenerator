---
kind: property
id: P:Autodesk.Revit.DB.DoubleArrayIterator.Current
source: html/791e7193-3767-2896-7dc1-4c9a7a3f8cf9.htm
---
# Autodesk.Revit.DB.DoubleArrayIterator.Current Property

Retrieves the item that is the current focus of the iterator.

## Syntax (C#)
```csharp
public virtual Object Current { get; }
```

## Remarks
A new or Reset iterator must have MoveNext called on it before Current will return a valid
 item as per expected behavior of IEnumerator.

