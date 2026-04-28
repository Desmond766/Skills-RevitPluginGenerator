---
kind: property
id: P:Autodesk.Revit.DB.DetailCurveArrayIterator.Current
source: html/b97affd1-b1dd-00ee-b3fb-bc02c3ba67f7.htm
---
# Autodesk.Revit.DB.DetailCurveArrayIterator.Current Property

Retrieves the item that is the current focus of the iterator.

## Syntax (C#)
```csharp
public virtual Object Current { get; }
```

## Remarks
A new or Reset iterator must have MoveNext called on it before Current will return a valid
 item as per expected behavior of IEnumerator.

