---
kind: property
id: P:Autodesk.Revit.DB.PlanTopologySetIterator.Current
source: html/1521a980-c9e9-ce1d-875e-a3092c59d4ec.htm
---
# Autodesk.Revit.DB.PlanTopologySetIterator.Current Property

Retrieves the item that is the current focus of the iterator.

## Syntax (C#)
```csharp
public virtual Object Current { get; }
```

## Remarks
A new or Reset iterator must have MoveNext called on it before Current will return a valid
 item as per expected behavior of IEnumerator.

