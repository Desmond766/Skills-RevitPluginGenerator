---
kind: property
id: P:Autodesk.Revit.DB.Structure.RebarContainerIterator.Current
source: html/f1e07751-c94e-761f-20f3-9a294c4976fb.htm
---
# Autodesk.Revit.DB.Structure.RebarContainerIterator.Current Property

Gets the item at the current position of the iterator.

## Syntax (C#)
```csharp
public virtual RebarContainerItem Current { get; }
```

## Remarks
There is no current item if the iterator has not started yet or has been done.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - There is no current item in the iterator.

