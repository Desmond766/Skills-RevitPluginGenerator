---
kind: property
id: P:Autodesk.Revit.DB.ReferenceArrayArrayIterator.Current
source: html/2efe1a46-2087-6042-4db4-89ef9c621efc.htm
---
# Autodesk.Revit.DB.ReferenceArrayArrayIterator.Current Property

Retrieves the item that is the current focus of the iterator.

## Syntax (C#)
```csharp
public virtual Object Current { get; }
```

## Remarks
A new or Reset iterator must have MoveNext called on it before Current will return a valid
 item as per expected behavior of IEnumerator.

