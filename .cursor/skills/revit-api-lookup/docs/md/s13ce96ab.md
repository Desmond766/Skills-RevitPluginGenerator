---
kind: property
id: P:Autodesk.Revit.DB.PlanCircuitSetIterator.Current
source: html/d15bb9ee-9789-795a-89b5-0edce6b87df6.htm
---
# Autodesk.Revit.DB.PlanCircuitSetIterator.Current Property

Retrieves the item that is the current focus of the iterator.

## Syntax (C#)
```csharp
public virtual Object Current { get; }
```

## Remarks
A new or Reset iterator must have MoveNext called on it before Current will return a valid
 item as per expected behavior of IEnumerator.

