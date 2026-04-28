---
kind: property
id: P:Autodesk.Revit.DB.LeaderArrayIterator.Current
source: html/67dd86d6-cb0b-fca7-978b-8ef19fd5b3e6.htm
---
# Autodesk.Revit.DB.LeaderArrayIterator.Current Property

Retrieves the item that is the current focus of the iterator.

## Syntax (C#)
```csharp
public virtual Object Current { get; }
```

## Remarks
A new or Reset iterator must have MoveNext called on it before Current will return a valid
 item as per expected behavior of IEnumerator.

