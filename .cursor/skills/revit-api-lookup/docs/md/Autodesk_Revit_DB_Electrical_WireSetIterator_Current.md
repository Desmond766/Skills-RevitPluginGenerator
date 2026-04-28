---
kind: property
id: P:Autodesk.Revit.DB.Electrical.WireSetIterator.Current
source: html/6a6d38f1-0d0c-e3e4-7efe-56de23bd2d4d.htm
---
# Autodesk.Revit.DB.Electrical.WireSetIterator.Current Property

Retrieves the item that is the current focus of the iterator.

## Syntax (C#)
```csharp
public virtual Object Current { get; }
```

## Remarks
A new or Reset iterator must have MoveNext called on it before Current will return a valid
 item as per expected behavior of IEnumerator.

