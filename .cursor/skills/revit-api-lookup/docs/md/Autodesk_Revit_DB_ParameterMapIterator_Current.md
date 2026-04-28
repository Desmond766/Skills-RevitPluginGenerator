---
kind: property
id: P:Autodesk.Revit.DB.ParameterMapIterator.Current
source: html/c39936cd-1755-7189-3daa-082552947b42.htm
---
# Autodesk.Revit.DB.ParameterMapIterator.Current Property

Retrieves the item that is the current focus of the iterator.

## Syntax (C#)
```csharp
public virtual Object Current { get; }
```

## Remarks
A new or Reset iterator must have MoveNext called on it before Current will return a valid
 item as per expected behavior of IEnumerator.

