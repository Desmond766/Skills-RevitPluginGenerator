---
kind: property
id: P:Autodesk.Revit.DB.Electrical.TemperatureRatingTypeSetIterator.Current
source: html/6cee6580-c855-14ae-14f1-d0cb7812dbdf.htm
---
# Autodesk.Revit.DB.Electrical.TemperatureRatingTypeSetIterator.Current Property

Retrieves the item that is the current focus of the iterator.

## Syntax (C#)
```csharp
public virtual Object Current { get; }
```

## Remarks
A new or Reset iterator must have MoveNext called on it before Current will return a valid
 item as per expected behavior of IEnumerator.

