---
kind: property
id: P:Autodesk.Revit.DB.CategoryNameMapIterator.Current
source: html/44efbc46-34a5-83be-4644-ad2bdddcba52.htm
---
# Autodesk.Revit.DB.CategoryNameMapIterator.Current Property

Retrieves the category that is the current focus of the iterator.

## Syntax (C#)
```csharp
public virtual Object Current { get; }
```

## Remarks
A new or Reset iterator must have MoveNext called on it before Current will return a valid
 item as per expected behavior of IEnumerator.

