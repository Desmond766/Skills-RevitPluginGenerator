---
kind: property
id: P:Autodesk.Revit.DB.FamilyTypeSetIterator.Current
source: html/c02b079a-b0da-5bc2-1984-96ffff785652.htm
---
# Autodesk.Revit.DB.FamilyTypeSetIterator.Current Property

Retrieves the item that is the current focus of the iterator.

## Syntax (C#)
```csharp
public virtual Object Current { get; }
```

## Remarks
A new or Reset iterator must have MoveNext called on it before Current will return a valid
 item as per expected behavior of IEnumerator.

