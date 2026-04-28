---
kind: method
id: M:Autodesk.Revit.DB.FilteredElementIdIterator.Reset
source: html/e478208b-3d1c-9ce1-1592-0faa8462469d.htm
---
# Autodesk.Revit.DB.FilteredElementIdIterator.Reset Method

Resets the iterator to the beginning.

## Syntax (C#)
```csharp
public virtual void Reset()
```

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The FilteredElementCollector that yielded this iterator has been reset by another operation.
 No further iteration is permitted with this iterator.

