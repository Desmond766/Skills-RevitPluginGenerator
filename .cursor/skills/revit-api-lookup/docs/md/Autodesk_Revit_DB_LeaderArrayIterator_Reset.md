---
kind: method
id: M:Autodesk.Revit.DB.LeaderArrayIterator.Reset
source: html/c8627d61-396e-ed2c-040a-8fa7261c2a65.htm
---
# Autodesk.Revit.DB.LeaderArrayIterator.Reset Method

Bring the iterator back to the start of the array.

## Syntax (C#)
```csharp
public virtual void Reset()
```

## Remarks
The Reset method will return the iterator back to the start of the array in line with the definition of IEnumerator. Note that you must call MoveNext before the first item can be accessed via the Current property.

