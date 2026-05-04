---
kind: property
id: P:Autodesk.Revit.DB.FilteredElementIterator.Current
source: html/43c20ff6-06fb-0b0e-0313-da296ab54fb7.htm
---
# Autodesk.Revit.DB.FilteredElementIterator.Current Property

Gets the item at the current position of the iterator.

## Syntax (C#)
```csharp
public virtual Element Current { get; }
```

## Remarks
There is no current item if the iterator has not started yet or has been done.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - There is no current item in the iterator.

