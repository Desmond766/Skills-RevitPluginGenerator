---
kind: property
id: P:Autodesk.Revit.DB.MullionTypeSetIterator.Current
source: html/4d8aae3d-73dc-5ceb-9f7a-fd2a5e3e0a86.htm
---
# Autodesk.Revit.DB.MullionTypeSetIterator.Current Property

Retrieves the item that is the current focus of the iterator.

## Syntax (C#)
```csharp
public virtual Object Current { get; }
```

## Remarks
A new or Reset iterator must have MoveNext called on it before Current will return a valid
 item as per expected behavior of IEnumerator.

