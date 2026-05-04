---
kind: method
id: M:Autodesk.Revit.DB.IntersectionResultArrayIterator.Reset
source: html/f9eadc51-c7ca-7898-a38d-f9d787bb76b6.htm
---
# Autodesk.Revit.DB.IntersectionResultArrayIterator.Reset Method

Bring the iterator back to the start of the array.

## Syntax (C#)
```csharp
public virtual void Reset()
```

## Remarks
The Reset method will return the iterator back to the start of the array in line with the definition of IEnumerator. Note that you must call MoveNext before the first item can be accessed via the Current property.

