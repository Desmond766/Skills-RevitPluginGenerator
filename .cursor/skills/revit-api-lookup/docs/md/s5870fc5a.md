---
kind: property
id: P:Autodesk.Revit.DB.IFC.IFCAggregateIterator.Current
source: html/38327d62-252c-b67b-98e0-25e623cecc03.htm
---
# Autodesk.Revit.DB.IFC.IFCAggregateIterator.Current Property

Gets the item at the current position of the iterator.

## Syntax (C#)
```csharp
public virtual IFCData Current { get; }
```

## Remarks
There is no current item if the iterator has not started yet or has been done.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - There is no current item in the iterator.

