---
kind: property
id: P:Autodesk.Revit.DB.Electrical.WireTypeSetIterator.Current
source: html/6ceacb38-56e2-cb1e-38a1-4444673c264d.htm
---
# Autodesk.Revit.DB.Electrical.WireTypeSetIterator.Current Property

Retrieves the item that is the current focus of the iterator.

## Syntax (C#)
```csharp
public virtual Object Current { get; }
```

## Remarks
A new or Reset iterator must have MoveNext called on it before Current will return a valid
 item as per expected behavior of IEnumerator.

