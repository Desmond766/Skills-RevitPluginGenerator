---
kind: property
id: P:Autodesk.Revit.DB.CurveLoopIterator.Current
source: html/40156af9-f8c3-b4cc-8528-c83fe85086b8.htm
---
# Autodesk.Revit.DB.CurveLoopIterator.Current Property

Gets the item at the current position of the iterator.

## Syntax (C#)
```csharp
public virtual Curve Current { get; }
```

## Remarks
There is no current item if the iterator has not started yet or has been done.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - There is no current item in the iterator.

