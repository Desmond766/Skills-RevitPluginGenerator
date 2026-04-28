---
kind: property
id: P:Autodesk.Revit.DB.Electrical.InsulationTypeSetIterator.Current
source: html/2de9a3a0-d203-47dc-357b-10cb12406544.htm
---
# Autodesk.Revit.DB.Electrical.InsulationTypeSetIterator.Current Property

Retrieves the item that is the current focus of the iterator.

## Syntax (C#)
```csharp
public virtual Object Current { get; }
```

## Remarks
A new or Reset iterator must have MoveNext called on it before Current will return a valid
 item as per expected behavior of IEnumerator.

