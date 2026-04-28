---
kind: property
id: P:Autodesk.Revit.DB.PhaseArrayIterator.Current
source: html/83012ed1-3b85-533b-886b-a596793ccd34.htm
---
# Autodesk.Revit.DB.PhaseArrayIterator.Current Property

Retrieves the item that is the current focus of the iterator.

## Syntax (C#)
```csharp
public virtual Object Current { get; }
```

## Remarks
A new or Reset iterator must have MoveNext called on it before Current will return a valid
 item as per expected behavior of IEnumerator.

