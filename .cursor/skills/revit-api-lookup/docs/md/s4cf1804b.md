---
kind: property
id: P:Autodesk.Revit.DB.Mechanical.DuctSizeIterator.Current
source: html/d1620fdc-e262-fc9e-16e9-dc1e7f2b03dc.htm
---
# Autodesk.Revit.DB.Mechanical.DuctSizeIterator.Current Property

Gets the item at the current position of the iterator.

## Syntax (C#)
```csharp
public virtual MEPSize Current { get; }
```

## Remarks
There is no current item if the iterator has not started yet or has been done.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - There is no current item in the iterator.

