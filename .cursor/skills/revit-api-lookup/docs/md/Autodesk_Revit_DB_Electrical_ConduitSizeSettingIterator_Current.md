---
kind: property
id: P:Autodesk.Revit.DB.Electrical.ConduitSizeSettingIterator.Current
source: html/a3ad07af-44db-6bcc-94eb-0f0a05d71937.htm
---
# Autodesk.Revit.DB.Electrical.ConduitSizeSettingIterator.Current Property

Gets the item at the current position of the iterator.

## Syntax (C#)
```csharp
public virtual KeyValuePair<string, ConduitSizes> Current { get; }
```

## Remarks
There is no current item if the iterator has not started yet or has been done.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - There is no current item in the iterator.

