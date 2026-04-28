---
kind: property
id: P:Autodesk.Revit.DB.SymbolicCurveArrayIterator.Current
source: html/cf3f90d3-62ad-9b25-0807-59bebfecf557.htm
---
# Autodesk.Revit.DB.SymbolicCurveArrayIterator.Current Property

Retrieves the item that is the current focus of the iterator.

## Syntax (C#)
```csharp
public virtual Object Current { get; }
```

## Remarks
A new or Reset iterator must have MoveNext called on it before Current will return a valid
 item as per expected behavior of IEnumerator.

