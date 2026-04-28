---
kind: property
id: P:Autodesk.Revit.DB.EdgeArrayArrayIterator.Current
source: html/fe6c3285-1723-017b-9f62-c3260596a1d6.htm
---
# Autodesk.Revit.DB.EdgeArrayArrayIterator.Current Property

Retrieves the item that is the current focus of the iterator.

## Syntax (C#)
```csharp
public virtual Object Current { get; }
```

## Remarks
A new or Reset iterator must have MoveNext called on it before Current will return a valid
 item as per expected behavior of IEnumerator.

