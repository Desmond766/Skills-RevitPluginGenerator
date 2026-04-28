---
kind: property
id: P:Autodesk.Revit.DB.DefinitionBindingMapIterator.Key
source: html/d94a5479-7f4b-d483-717c-fb9ec1bb2e63.htm
---
# Autodesk.Revit.DB.DefinitionBindingMapIterator.Key Property

Retrieves the definition that is the current focus of the iterator.

## Syntax (C#)
```csharp
public virtual Definition Key { get; }
```

## Remarks
A new or Reset iterator must have MoveNext called on it before Current will return a valid
 key as per expected behavior of IEnumerator.

