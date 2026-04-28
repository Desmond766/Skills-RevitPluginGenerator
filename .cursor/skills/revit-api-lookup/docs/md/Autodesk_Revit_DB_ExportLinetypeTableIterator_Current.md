---
kind: property
id: P:Autodesk.Revit.DB.ExportLinetypeTableIterator.Current
source: html/4769f1a9-53b5-df7a-3aee-a2b8f0e09aa2.htm
---
# Autodesk.Revit.DB.ExportLinetypeTableIterator.Current Property

Gets the item at the current position of the iterator.

## Syntax (C#)
```csharp
public virtual KeyValuePair<ExportLinetypeKey, ExportLinetypeInfo> Current { get; }
```

## Remarks
There is no current item if the iterator has not started yet or has been done.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - There is no current item in the iterator.

