---
kind: property
id: P:Autodesk.Revit.DB.PaperSourceSetIterator.Current
source: html/90d4aafe-0c68-e02f-2a3c-2971d320c739.htm
---
# Autodesk.Revit.DB.PaperSourceSetIterator.Current Property

Retrieves the item that is the current focus of the iterator.

## Syntax (C#)
```csharp
public virtual Object Current { get; }
```

## Remarks
A new or Reset iterator must have MoveNext called on it before Current will return a valid
 item as per expected behavior of IEnumerator.

