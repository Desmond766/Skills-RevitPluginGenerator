---
kind: property
id: P:Autodesk.Revit.DB.Electrical.CorrectionFactorSetIterator.Current
source: html/d5a3068d-01b1-44b0-61d9-cad0f05df986.htm
---
# Autodesk.Revit.DB.Electrical.CorrectionFactorSetIterator.Current Property

Retrieves the item that is the current focus of the iterator.

## Syntax (C#)
```csharp
public virtual Object Current { get; }
```

## Remarks
A new or Reset iterator must have MoveNext called on it before Current will return a valid
 item as per expected behavior of IEnumerator.

