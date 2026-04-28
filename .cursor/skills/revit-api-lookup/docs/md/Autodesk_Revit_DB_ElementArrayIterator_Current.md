---
kind: property
id: P:Autodesk.Revit.DB.ElementArrayIterator.Current
source: html/721cac1e-fb88-15c8-0068-bce60ed55f0c.htm
---
# Autodesk.Revit.DB.ElementArrayIterator.Current Property

Retrieves the item that is the current focus of the iterator.

## Syntax (C#)
```csharp
public virtual Object Current { get; }
```

## Remarks
A new or Reset iterator must have MoveNext called on it before Current will return a valid
 item as per expected behavior of IEnumerator.

