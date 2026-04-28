---
kind: property
id: P:Autodesk.Revit.DB.ElementSetIterator.Current
source: html/2e6adfca-9bb5-3f80-9a40-f6f37ad6051e.htm
---
# Autodesk.Revit.DB.ElementSetIterator.Current Property

Retrieves the item that is the current focus of the iterator.

## Syntax (C#)
```csharp
public virtual Object Current { get; }
```

## Remarks
A new or Reset iterator must have MoveNext called on it before Current will return a valid
 item as per expected behavior of IEnumerator.

