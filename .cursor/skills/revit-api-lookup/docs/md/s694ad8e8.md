---
kind: property
id: P:Autodesk.Revit.DB.ReferencePointArrayIterator.Current
source: html/996fc244-f6d4-b657-0202-4912932fbc1a.htm
---
# Autodesk.Revit.DB.ReferencePointArrayIterator.Current Property

Retrieves the item that is the current focus of the iterator.

## Syntax (C#)
```csharp
public virtual Object Current { get; }
```

## Remarks
A new or Reset iterator must have MoveNext called on it before Current will return a valid
 item as per expected behavior of IEnumerator.

