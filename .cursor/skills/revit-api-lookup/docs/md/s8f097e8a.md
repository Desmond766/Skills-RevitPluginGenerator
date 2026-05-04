---
kind: property
id: P:Autodesk.Revit.DB.IntersectionResultArrayIterator.Current
source: html/9b5bed92-8bcf-a48a-bb82-7f4691b0c82c.htm
---
# Autodesk.Revit.DB.IntersectionResultArrayIterator.Current Property

Retrieves the item that is the current focus of the iterator.

## Syntax (C#)
```csharp
public virtual Object Current { get; }
```

## Remarks
A new or Reset iterator must have MoveNext called on it before Current will return a valid
 item as per expected behavior of IEnumerator.

