---
kind: property
id: P:Autodesk.Revit.DB.ExportLineweightTableIterator.Current
source: html/5dee5410-9cb5-5053-a9bb-bd83280dc983.htm
---
# Autodesk.Revit.DB.ExportLineweightTableIterator.Current Property

Gets the item at the current position of the iterator.

## Syntax (C#)
```csharp
public virtual KeyValuePair<ExportLineweightKey, ExportLineweightInfo> Current { get; }
```

## Remarks
There is no current item if the iterator has not started yet or has been done.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - There is no current item in the iterator.

