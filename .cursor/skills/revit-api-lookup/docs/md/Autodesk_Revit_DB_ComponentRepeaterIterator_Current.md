---
kind: property
id: P:Autodesk.Revit.DB.ComponentRepeaterIterator.Current
source: html/904829e9-5046-61b4-026c-37a384d92cef.htm
---
# Autodesk.Revit.DB.ComponentRepeaterIterator.Current Property

Gets the item at the current position of the iterator.

## Syntax (C#)
```csharp
public virtual ComponentRepeaterSlot Current { get; }
```

## Remarks
There is no current item if the iterator has not started yet or has been done.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - There is no current item in the iterator.

