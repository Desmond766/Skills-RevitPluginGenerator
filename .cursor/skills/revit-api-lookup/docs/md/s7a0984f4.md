---
kind: property
id: P:Autodesk.Revit.DB.Electrical.DistributionSysTypeSetIterator.Current
source: html/893a9bd3-6f23-b9f2-cd5e-91e7db9ecf67.htm
---
# Autodesk.Revit.DB.Electrical.DistributionSysTypeSetIterator.Current Property

Retrieves the item that is the current focus of the iterator.

## Syntax (C#)
```csharp
public virtual Object Current { get; }
```

## Remarks
A new or Reset iterator must have MoveNext called on it before Current will return a valid
 item as per expected behavior of IEnumerator.

