---
kind: property
id: P:Autodesk.Revit.DB.Mechanical.SpaceSetIterator.Current
source: html/2220f6e8-ea45-2489-96de-33f91a9885f7.htm
---
# Autodesk.Revit.DB.Mechanical.SpaceSetIterator.Current Property

Retrieves the item that is the current focus of the iterator.

## Syntax (C#)
```csharp
public virtual Object Current { get; }
```

## Remarks
A new or Reset iterator must have MoveNext called on it before Current will return a valid
 item as per expected behavior of IEnumerator.

