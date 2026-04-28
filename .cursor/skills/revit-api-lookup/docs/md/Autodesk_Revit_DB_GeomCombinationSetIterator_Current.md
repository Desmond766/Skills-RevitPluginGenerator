---
kind: property
id: P:Autodesk.Revit.DB.GeomCombinationSetIterator.Current
source: html/3b05e6fa-f8e4-1eda-3456-8a8287f1d3e0.htm
---
# Autodesk.Revit.DB.GeomCombinationSetIterator.Current Property

Retrieves the item that is the current focus of the iterator.

## Syntax (C#)
```csharp
public virtual Object Current { get; }
```

## Remarks
A new or Reset iterator must have MoveNext called on it before Current will return a valid
 item as per expected behavior of IEnumerator.

