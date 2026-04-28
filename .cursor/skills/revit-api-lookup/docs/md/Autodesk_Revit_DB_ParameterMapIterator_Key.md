---
kind: property
id: P:Autodesk.Revit.DB.ParameterMapIterator.Key
source: html/5dc55032-c022-087a-23ee-1020b164ace7.htm
---
# Autodesk.Revit.DB.ParameterMapIterator.Key Property

Retrieves the key that is the current focus of the iterator.

## Syntax (C#)
```csharp
public virtual string Key { get; }
```

## Remarks
A new or Reset iterator must have MoveNext called on it before Current will return a valid
 key as per expected behavior of IEnumerator.

