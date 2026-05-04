---
kind: property
id: P:Autodesk.Revit.DB.Electrical.VoltageTypeSetIterator.Current
source: html/85ad7768-e581-e529-be17-93c6d0e362d4.htm
---
# Autodesk.Revit.DB.Electrical.VoltageTypeSetIterator.Current Property

Retrieves the item that is the current focus of the iterator.

## Syntax (C#)
```csharp
public virtual Object Current { get; }
```

## Remarks
A new or Reset iterator must have MoveNext called on it before Current will return a valid
 item as per expected behavior of IEnumerator.

