---
kind: property
id: P:Autodesk.Revit.DB.DimensionSegmentArrayIterator.Current
source: html/712de2c8-49e4-7a96-4151-efca02f71989.htm
---
# Autodesk.Revit.DB.DimensionSegmentArrayIterator.Current Property

Retrieves the item that is the current focus of the iterator.

## Syntax (C#)
```csharp
public virtual Object Current { get; }
```

## Remarks
A new or Reset iterator must have MoveNext called on it before Current will return a valid
 item as per expected behavior of IEnumerator.

