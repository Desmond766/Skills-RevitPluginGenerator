---
kind: property
id: P:Autodesk.Revit.DB.ProjectLocationSetIterator.Current
source: html/5f3943cc-9033-6d2e-60ad-12b50eeffa4e.htm
---
# Autodesk.Revit.DB.ProjectLocationSetIterator.Current Property

Retrieves the item that is the current focus of the iterator.

## Syntax (C#)
```csharp
public virtual Object Current { get; }
```

## Remarks
A new or Reset iterator must have MoveNext called on it before Current will return a valid
 item as per expected behavior of IEnumerator.

