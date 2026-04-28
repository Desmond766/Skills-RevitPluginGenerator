---
kind: property
id: P:Autodesk.Revit.DB.CurveByPointsArrayIterator.Current
source: html/7dbc9961-7b3c-aabb-795b-c2bf4718a9a5.htm
---
# Autodesk.Revit.DB.CurveByPointsArrayIterator.Current Property

Retrieves the item that is the current focus of the iterator.

## Syntax (C#)
```csharp
public virtual Object Current { get; }
```

## Remarks
A new or Reset iterator must have MoveNext called on it before Current will return a valid
 item as per expected behavior of IEnumerator.

