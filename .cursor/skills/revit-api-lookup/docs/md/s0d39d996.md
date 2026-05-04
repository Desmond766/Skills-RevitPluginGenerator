---
kind: property
id: P:Autodesk.Revit.DB.Macros.MacroManagerIterator.Current
source: html/1d5dc2e5-fd8a-c30e-0d57-488d747f5d41.htm
---
# Autodesk.Revit.DB.Macros.MacroManagerIterator.Current Property

Gets the item at the current position of the iterator.

## Syntax (C#)
```csharp
public virtual MacroModule Current { get; }
```

## Remarks
There is no current item if the iterator has not started yet or has been done.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - There is no current item in the iterator.

