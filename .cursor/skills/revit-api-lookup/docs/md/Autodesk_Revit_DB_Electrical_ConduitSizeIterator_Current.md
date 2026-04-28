---
kind: property
id: P:Autodesk.Revit.DB.Electrical.ConduitSizeIterator.Current
source: html/e69bfad3-dc3e-1bd2-1508-ba8c406699fd.htm
---
# Autodesk.Revit.DB.Electrical.ConduitSizeIterator.Current Property

Gets the item at the current position of the iterator.

## Syntax (C#)
```csharp
public virtual ConduitSize Current { get; }
```

## Remarks
There is no current item if the iterator has not started yet or has been done.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - There is no current item in the iterator.

