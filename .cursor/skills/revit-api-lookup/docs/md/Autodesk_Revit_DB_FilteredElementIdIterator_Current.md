---
kind: property
id: P:Autodesk.Revit.DB.FilteredElementIdIterator.Current
source: html/d37acf89-a76e-f310-ff9e-056c5857172f.htm
---
# Autodesk.Revit.DB.FilteredElementIdIterator.Current Property

Gets the item at the current position of the iterator.

## Syntax (C#)
```csharp
public virtual ElementId Current { get; }
```

## Remarks
There is no current item if the iterator has not started yet or has been done.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - There is no current item in the iterator.

