---
kind: property
id: P:Autodesk.Revit.DB.Electrical.WireSizeSetIterator.Current
source: html/e6b5baa3-3f9e-4087-99ed-06b7bcbab7d3.htm
---
# Autodesk.Revit.DB.Electrical.WireSizeSetIterator.Current Property

Retrieves the item that is the current focus of the iterator.

## Syntax (C#)
```csharp
public virtual Object Current { get; }
```

## Remarks
A new or Reset iterator must have MoveNext called on it before Current will return a valid
 item as per expected behavior of IEnumerator.

