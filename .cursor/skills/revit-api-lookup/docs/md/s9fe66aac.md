---
kind: property
id: P:Autodesk.Revit.DB.Macros.MacroModuleIterator.Current
source: html/423853c6-d711-2a8d-7cce-9df6b3f3e2be.htm
---
# Autodesk.Revit.DB.Macros.MacroModuleIterator.Current Property

Gets the item at the current position of the iterator.

## Syntax (C#)
```csharp
public virtual Macro Current { get; }
```

## Remarks
There is no current item if the iterator has not started yet or has been done.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - There is no current item in the iterator.

