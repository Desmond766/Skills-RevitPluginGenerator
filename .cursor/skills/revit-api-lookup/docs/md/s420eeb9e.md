---
kind: property
id: P:Autodesk.Revit.DB.ConnectorSetIterator.Current
source: html/77a31a9c-7e57-7818-84a4-1067916c8773.htm
---
# Autodesk.Revit.DB.ConnectorSetIterator.Current Property

Retrieves the item that is the current focus of the iterator.

## Syntax (C#)
```csharp
public virtual Object Current { get; }
```

## Remarks
A new or Reset iterator must have MoveNext called on it before Current will return a valid
 item as per expected behavior of IEnumerator.

