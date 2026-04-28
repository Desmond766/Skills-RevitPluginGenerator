---
kind: property
id: P:Autodesk.Revit.DB.DefinitionBindingMapIterator.Current
source: html/85a528cd-a15b-263f-5849-6dccb567250b.htm
---
# Autodesk.Revit.DB.DefinitionBindingMapIterator.Current Property

Retrieves the binding that is the current focus of the iterator.

## Syntax (C#)
```csharp
public virtual Object Current { get; }
```

## Remarks
A new or Reset iterator must have MoveNext called on it before Current will return a valid
 item as per expected behavior of IEnumerator.

