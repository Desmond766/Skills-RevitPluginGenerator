---
kind: property
id: P:Autodesk.Revit.DB.PaperSizeSetIterator.Current
source: html/4fcedb03-4540-d989-ccc9-eb2f8b996f4a.htm
---
# Autodesk.Revit.DB.PaperSizeSetIterator.Current Property

Retrieves the item that is the current focus of the iterator.

## Syntax (C#)
```csharp
public virtual Object Current { get; }
```

## Remarks
A new or Reset iterator must have MoveNext called on it before Current will return a valid
 item as per expected behavior of IEnumerator.

