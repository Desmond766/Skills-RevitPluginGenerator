---
kind: property
id: P:Autodesk.Revit.DB.CategorySetIterator.Current
source: html/e1ed6e87-6fb6-3057-b649-b56491e2e4e8.htm
---
# Autodesk.Revit.DB.CategorySetIterator.Current Property

Retrieves the item that is the current focus of the iterator.

## Syntax (C#)
```csharp
public virtual Object Current { get; }
```

## Remarks
A new or Reset iterator must have MoveNext called on it before Current will return a valid
 item as per expected behavior of IEnumerator.

