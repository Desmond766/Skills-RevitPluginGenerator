---
kind: property
id: P:Autodesk.Revit.DB.FilteredWorksetIdIterator.Current
source: html/ba1f2d85-898b-2985-7a0d-2fc7bbb29430.htm
---
# Autodesk.Revit.DB.FilteredWorksetIdIterator.Current Property

Gets the item at the current position of the iterator.

## Syntax (C#)
```csharp
public virtual WorksetId Current { get; }
```

## Remarks
There is no current item if the iterator has not started yet or has been done.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - There is no current item in the iterator.

