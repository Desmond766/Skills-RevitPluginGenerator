---
kind: property
id: P:Autodesk.Revit.UI.ExternalApplicationArrayIterator.Current
source: html/4c177370-b10a-70ad-4ec5-6c0e41fddfd3.htm
---
# Autodesk.Revit.UI.ExternalApplicationArrayIterator.Current Property

Retrieves the item that is the current focus of the iterator.

## Syntax (C#)
```csharp
public virtual Object Current { get; }
```

## Remarks
A new or Reset iterator must have MoveNext called on it before Current will return a valid
 item as per expected behavior of IEnumerator.

