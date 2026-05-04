---
kind: property
id: P:Autodesk.Revit.DB.EdgeArrayIterator.Current
source: html/556b93e6-482c-5744-8f71-a24fc14fd1e3.htm
---
# Autodesk.Revit.DB.EdgeArrayIterator.Current Property

Retrieves the item that is the current focus of the iterator.

## Syntax (C#)
```csharp
public virtual Object Current { get; }
```

## Remarks
A new or Reset iterator must have MoveNext called on it before Current will return a valid
 item as per expected behavior of IEnumerator.

