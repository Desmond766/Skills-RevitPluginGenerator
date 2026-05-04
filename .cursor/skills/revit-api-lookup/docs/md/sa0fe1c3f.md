---
kind: property
id: P:Autodesk.Revit.DB.FilteredWorksetIterator.Current
source: html/7c3c158e-3da6-4e7e-ec0a-88381c825ba8.htm
---
# Autodesk.Revit.DB.FilteredWorksetIterator.Current Property

Gets the item at the current position of the iterator.

## Syntax (C#)
```csharp
public virtual Workset Current { get; }
```

## Remarks
There is no current item if the iterator has not started yet or has been done.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - There is no current item in the iterator.

