---
kind: property
id: P:Autodesk.Revit.DB.GroupSetIterator.Current
source: html/79e54362-cc13-8068-99cc-2e7216d5beb6.htm
---
# Autodesk.Revit.DB.GroupSetIterator.Current Property

Retrieves the item that is the current focus of the iterator.

## Syntax (C#)
```csharp
public virtual Object Current { get; }
```

## Remarks
A new or Reset iterator must have MoveNext called on it before Current will return a valid
 item as per expected behavior of IEnumerator.

