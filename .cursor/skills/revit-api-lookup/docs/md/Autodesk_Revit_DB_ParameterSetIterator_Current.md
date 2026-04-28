---
kind: property
id: P:Autodesk.Revit.DB.ParameterSetIterator.Current
source: html/0a1fbe9f-4945-3950-21ec-403d18a5668b.htm
---
# Autodesk.Revit.DB.ParameterSetIterator.Current Property

Retrieves the item that is the current focus of the iterator.

## Syntax (C#)
```csharp
public virtual Object Current { get; }
```

## Remarks
A new or Reset iterator must have MoveNext called on it before Current will return a valid
 item as per expected behavior of IEnumerator.

