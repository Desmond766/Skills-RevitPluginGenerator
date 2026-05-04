---
kind: property
id: P:Autodesk.Revit.DB.CurveArrayIterator.Current
source: html/bd10649b-0bf8-747c-8f2a-b42d4222cd40.htm
---
# Autodesk.Revit.DB.CurveArrayIterator.Current Property

Retrieves the item that is the current focus of the iterator.

## Syntax (C#)
```csharp
public virtual Object Current { get; }
```

## Remarks
A new or Reset iterator must have MoveNext called on it before Current will return a valid
 item as per expected behavior of IEnumerator.

