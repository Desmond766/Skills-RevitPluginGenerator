---
kind: property
id: P:Autodesk.Revit.DB.ExportPatternTableIterator.Current
source: html/86d9d1ba-f873-d678-f5d0-48f37d8d0d76.htm
---
# Autodesk.Revit.DB.ExportPatternTableIterator.Current Property

Gets the item at the current position of the iterator.

## Syntax (C#)
```csharp
public virtual KeyValuePair<ExportPatternKey, ExportPatternInfo> Current { get; }
```

## Remarks
There is no current item if the iterator has not started yet or has been done.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - There is no current item in the iterator.

