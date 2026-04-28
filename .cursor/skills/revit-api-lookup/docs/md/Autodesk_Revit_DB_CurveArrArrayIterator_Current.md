---
kind: property
id: P:Autodesk.Revit.DB.CurveArrArrayIterator.Current
source: html/074d8dfc-b6f7-1d8f-4fa9-60505024ff0f.htm
---
# Autodesk.Revit.DB.CurveArrArrayIterator.Current Property

Retrieves the item that is the current focus of the iterator.

## Syntax (C#)
```csharp
public virtual Object Current { get; }
```

## Remarks
A new or Reset iterator must have MoveNext called on it before Current will return a valid
 item as per expected behavior of IEnumerator.

