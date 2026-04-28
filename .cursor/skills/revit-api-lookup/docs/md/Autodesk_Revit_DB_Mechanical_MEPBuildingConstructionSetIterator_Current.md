---
kind: property
id: P:Autodesk.Revit.DB.Mechanical.MEPBuildingConstructionSetIterator.Current
source: html/0f8ee6bc-ec8b-79a5-f7f3-032b8acb27e7.htm
---
# Autodesk.Revit.DB.Mechanical.MEPBuildingConstructionSetIterator.Current Property

Retrieves the item that is the current focus of the iterator.

## Syntax (C#)
```csharp
public virtual Object Current { get; }
```

## Remarks
A new or Reset iterator must have MoveNext called on it before Current will return a valid
 item as per expected behavior of IEnumerator.

