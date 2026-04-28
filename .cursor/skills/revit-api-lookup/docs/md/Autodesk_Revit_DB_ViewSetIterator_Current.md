---
kind: property
id: P:Autodesk.Revit.DB.ViewSetIterator.Current
source: html/a1315a34-907d-ac38-3ab8-c422c77269bb.htm
---
# Autodesk.Revit.DB.ViewSetIterator.Current Property

Retrieves the item that is the current focus of the iterator.

## Syntax (C#)
```csharp
public virtual Object Current { get; }
```

## Remarks
A new or Reset iterator must have MoveNext called on it before Current will return a valid
 item as per expected behavior of IEnumerator.

