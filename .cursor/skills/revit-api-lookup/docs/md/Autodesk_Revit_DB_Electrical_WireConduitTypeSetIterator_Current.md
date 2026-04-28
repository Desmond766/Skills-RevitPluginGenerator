---
kind: property
id: P:Autodesk.Revit.DB.Electrical.WireConduitTypeSetIterator.Current
source: html/a6068053-4079-a4b6-794d-b0d9e0482b82.htm
---
# Autodesk.Revit.DB.Electrical.WireConduitTypeSetIterator.Current Property

Retrieves the item that is the current focus of the iterator.

## Syntax (C#)
```csharp
public virtual Object Current { get; }
```

## Remarks
A new or Reset iterator must have MoveNext called on it before Current will return a valid
 item as per expected behavior of IEnumerator.

