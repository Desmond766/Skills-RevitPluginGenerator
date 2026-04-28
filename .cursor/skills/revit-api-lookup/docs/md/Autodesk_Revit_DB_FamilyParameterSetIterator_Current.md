---
kind: property
id: P:Autodesk.Revit.DB.FamilyParameterSetIterator.Current
source: html/e2d62eb2-eec4-7074-9651-f1107441f1b1.htm
---
# Autodesk.Revit.DB.FamilyParameterSetIterator.Current Property

Retrieves the item that is the current focus of the iterator.

## Syntax (C#)
```csharp
public virtual Object Current { get; }
```

## Remarks
A new or Reset iterator must have MoveNext called on it before Current will return a valid
 item as per expected behavior of IEnumerator.

