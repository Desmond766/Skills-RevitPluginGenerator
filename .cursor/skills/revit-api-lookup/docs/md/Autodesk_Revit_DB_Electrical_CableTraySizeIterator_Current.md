---
kind: property
id: P:Autodesk.Revit.DB.Electrical.CableTraySizeIterator.Current
source: html/4630e1ba-2b2f-05c9-1006-8adc936ea769.htm
---
# Autodesk.Revit.DB.Electrical.CableTraySizeIterator.Current Property

Gets the item at the current position of the iterator.

## Syntax (C#)
```csharp
public virtual MEPSize Current { get; }
```

## Remarks
There is no current item if the iterator has not started yet or has been done.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - There is no current item in the iterator.

