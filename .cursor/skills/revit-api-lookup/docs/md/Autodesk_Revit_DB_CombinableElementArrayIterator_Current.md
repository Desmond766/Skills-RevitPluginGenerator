---
kind: property
id: P:Autodesk.Revit.DB.CombinableElementArrayIterator.Current
source: html/98db3a43-e4c2-efc9-4e7e-a41e90d35330.htm
---
# Autodesk.Revit.DB.CombinableElementArrayIterator.Current Property

Retrieves the item that is the current focus of the iterator.

## Syntax (C#)
```csharp
public virtual Object Current { get; }
```

## Remarks
A new or Reset iterator must have MoveNext called on it before Current will return a valid
 item as per expected behavior of IEnumerator.

