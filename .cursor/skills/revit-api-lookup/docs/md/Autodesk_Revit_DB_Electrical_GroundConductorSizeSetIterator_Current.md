---
kind: property
id: P:Autodesk.Revit.DB.Electrical.GroundConductorSizeSetIterator.Current
source: html/acca0575-1591-83d1-055d-bf30d1d00a22.htm
---
# Autodesk.Revit.DB.Electrical.GroundConductorSizeSetIterator.Current Property

Retrieves the item that is the current focus of the iterator.

## Syntax (C#)
```csharp
public virtual Object Current { get; }
```

## Remarks
A new or Reset iterator must have MoveNext called on it before Current will return a valid
 item as per expected behavior of IEnumerator.

