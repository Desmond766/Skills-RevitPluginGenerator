---
kind: property
id: P:Autodesk.Revit.DB.ExportLayerTableIterator.Current
source: html/a4eb9d4d-7626-e8e4-5c91-65612b323ec7.htm
---
# Autodesk.Revit.DB.ExportLayerTableIterator.Current Property

Gets the item at the current position of the iterator.

## Syntax (C#)
```csharp
public virtual KeyValuePair<ExportLayerKey, ExportLayerInfo> Current { get; }
```

## Remarks
There is no current item if the iterator has not started yet or has been done.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - There is no current item in the iterator.

