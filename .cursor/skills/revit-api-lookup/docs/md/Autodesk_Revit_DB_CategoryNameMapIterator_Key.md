---
kind: property
id: P:Autodesk.Revit.DB.CategoryNameMapIterator.Key
source: html/b91c3f93-f753-8b70-aa89-1dd1ec38375a.htm
---
# Autodesk.Revit.DB.CategoryNameMapIterator.Key Property

Retrieves the category name that is the current focus of the iterator.

## Syntax (C#)
```csharp
public virtual string Key { get; }
```

## Remarks
A new or Reset iterator must have MoveNext called on it before Current will return a valid
 key as per expected behavior of IEnumerator.

