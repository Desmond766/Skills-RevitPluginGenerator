---
kind: property
id: P:Autodesk.Revit.DB.FormArrayIterator.Current
source: html/00ad01bb-55ff-316c-ea47-2019ba2a62c7.htm
---
# Autodesk.Revit.DB.FormArrayIterator.Current Property

Retrieves the item that is the current focus of the iterator.

## Syntax (C#)
```csharp
public virtual Object Current { get; }
```

## Remarks
A new or Reset iterator must have MoveNext called on it before Current will return a valid
 item as per expected behavior of IEnumerator.

