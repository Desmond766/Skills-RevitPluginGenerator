---
kind: property
id: P:Autodesk.Revit.DB.PanelTypeSetIterator.Current
source: html/33b17065-fda6-4e28-452e-708c0a6cff24.htm
---
# Autodesk.Revit.DB.PanelTypeSetIterator.Current Property

Retrieves the item that is the current focus of the iterator.

## Syntax (C#)
```csharp
public virtual Object Current { get; }
```

## Remarks
A new or Reset iterator must have MoveNext called on it before Current will return a valid
 item as per expected behavior of IEnumerator.

