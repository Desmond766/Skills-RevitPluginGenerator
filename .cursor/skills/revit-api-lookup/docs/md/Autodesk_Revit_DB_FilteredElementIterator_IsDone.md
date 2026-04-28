---
kind: method
id: M:Autodesk.Revit.DB.FilteredElementIterator.IsDone
source: html/7016121a-df20-aa07-d6aa-553cbba587ad.htm
---
# Autodesk.Revit.DB.FilteredElementIterator.IsDone Method

Identifies if the iteration has completed.

## Syntax (C#)
```csharp
public virtual bool IsDone()
```

## Returns
True if the iteration has no more matching elements. False if there are more element ids to be iterated.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The FilteredElementCollector that yielded this iterator has been reset by another operation.
 No further iteration is permitted with this iterator.

