---
kind: property
id: P:Autodesk.Revit.DB.Mechanical.DuctSizeSettingIterator.Current
source: html/d44ecb68-80fb-59af-f44e-eaf674969903.htm
---
# Autodesk.Revit.DB.Mechanical.DuctSizeSettingIterator.Current Property

Gets the item at the current position of the iterator.

## Syntax (C#)
```csharp
public virtual KeyValuePair<DuctShape, DuctSizes> Current { get; }
```

## Remarks
There is no current item if the iterator has not started yet or has been done.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - There is no current item in the iterator.

