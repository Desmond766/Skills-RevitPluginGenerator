---
kind: property
id: P:Autodesk.Revit.DB.Plumbing.FluidTemperatureSetIterator.Current
source: html/30e48d5b-e280-0aaa-e615-fca90d069055.htm
---
# Autodesk.Revit.DB.Plumbing.FluidTemperatureSetIterator.Current Property

Gets the item at the current position of the iterator.

## Syntax (C#)
```csharp
public virtual FluidTemperature Current { get; }
```

## Remarks
There is no current item if the iterator has not started yet or has been done.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - There is no current item in the iterator.

