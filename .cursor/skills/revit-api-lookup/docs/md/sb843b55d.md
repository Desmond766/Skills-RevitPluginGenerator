---
kind: property
id: P:Autodesk.Revit.DB.DocumentSetIterator.Current
source: html/897de9dd-b0a4-7cc1-f81c-5e546e3d109a.htm
---
# Autodesk.Revit.DB.DocumentSetIterator.Current Property

Retrieves the item that is the current focus of the iterator.

## Syntax (C#)
```csharp
public virtual Object Current { get; }
```

## Remarks
A new or Reset iterator must have MoveNext called on it before Current will return a valid
 item as per expected behavior of IEnumerator.

