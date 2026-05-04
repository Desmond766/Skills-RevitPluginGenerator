---
kind: property
id: P:Autodesk.Revit.DB.ExportFontTableIterator.Current
source: html/39f76008-5a52-cb59-9bb8-9736e7ea8f9c.htm
---
# Autodesk.Revit.DB.ExportFontTableIterator.Current Property

Gets the item at the current position of the iterator.

## Syntax (C#)
```csharp
public virtual KeyValuePair<ExportFontKey, ExportFontInfo> Current { get; }
```

## Remarks
There is no current item if the iterator has not started yet or has been done.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - There is no current item in the iterator.

