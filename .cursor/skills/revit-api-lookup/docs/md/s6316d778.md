---
kind: method
id: M:Autodesk.Revit.DB.FilteredElementIterator.Reset
source: html/71fe4c5b-2975-6b7f-d945-0ea32275db54.htm
---
# Autodesk.Revit.DB.FilteredElementIterator.Reset Method

Resets the iterator to the beginning.

## Syntax (C#)
```csharp
public virtual void Reset()
```

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The FilteredElementCollector that yielded this iterator has been reset by another operation.
 No further iteration is permitted with this iterator.

