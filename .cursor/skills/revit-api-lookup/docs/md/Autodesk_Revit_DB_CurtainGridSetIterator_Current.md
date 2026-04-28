---
kind: property
id: P:Autodesk.Revit.DB.CurtainGridSetIterator.Current
source: html/75e8479b-2d95-e0fd-a35e-7eb5d13345df.htm
---
# Autodesk.Revit.DB.CurtainGridSetIterator.Current Property

Retrieves the item that is the current focus of the iterator.

## Syntax (C#)
```csharp
public virtual Object Current { get; }
```

## Remarks
A new or Reset iterator must have MoveNext called on it before Current will return a valid
 item as per expected behavior of IEnumerator.

