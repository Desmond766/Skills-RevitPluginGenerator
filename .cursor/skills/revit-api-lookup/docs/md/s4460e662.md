---
kind: property
id: P:Autodesk.Revit.DB.KeyBasedTreeEntriesIterator.Current
source: html/3bad88bc-139c-a0a9-39b6-4c048ef2313a.htm
---
# Autodesk.Revit.DB.KeyBasedTreeEntriesIterator.Current Property

Gets the item at the current position of the iterator.

## Syntax (C#)
```csharp
public virtual KeyBasedTreeEntry Current { get; }
```

## Remarks
There is no current item if the iterator has not started yet or has been done.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - There is no current item in the iterator.

