---
kind: property
id: P:Autodesk.Revit.DB.ModelCurveArrayIterator.Current
source: html/bdaf70a9-8900-d5ff-00eb-86dd8fdde961.htm
---
# Autodesk.Revit.DB.ModelCurveArrayIterator.Current Property

Retrieves the item that is the current focus of the iterator.

## Syntax (C#)
```csharp
public virtual Object Current { get; }
```

## Remarks
A new or Reset iterator must have MoveNext called on it before Current will return a valid
 item as per expected behavior of IEnumerator.

