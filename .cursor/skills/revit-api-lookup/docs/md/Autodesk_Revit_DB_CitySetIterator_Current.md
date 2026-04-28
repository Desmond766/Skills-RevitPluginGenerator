---
kind: property
id: P:Autodesk.Revit.DB.CitySetIterator.Current
source: html/242376ef-21ed-10b6-ac1c-c99679740888.htm
---
# Autodesk.Revit.DB.CitySetIterator.Current Property

Retrieves the item that is the current focus of the iterator.

## Syntax (C#)
```csharp
public virtual Object Current { get; }
```

## Remarks
A new or Reset iterator must have MoveNext called on it before Current will return a valid
 item as per expected behavior of IEnumerator.

