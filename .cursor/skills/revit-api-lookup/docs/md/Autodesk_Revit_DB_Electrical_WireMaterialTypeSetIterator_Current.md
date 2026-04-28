---
kind: property
id: P:Autodesk.Revit.DB.Electrical.WireMaterialTypeSetIterator.Current
source: html/ff709bd7-493e-62e9-0ee8-67b161a2c497.htm
---
# Autodesk.Revit.DB.Electrical.WireMaterialTypeSetIterator.Current Property

Retrieves the item that is the current focus of the iterator.

## Syntax (C#)
```csharp
public virtual Object Current { get; }
```

## Remarks
A new or Reset iterator must have MoveNext called on it before Current will return a valid
 item as per expected behavior of IEnumerator.

