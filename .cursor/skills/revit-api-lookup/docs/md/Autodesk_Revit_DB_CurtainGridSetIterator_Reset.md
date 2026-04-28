---
kind: method
id: M:Autodesk.Revit.DB.CurtainGridSetIterator.Reset
source: html/f6eeb9c9-1fa2-a023-febc-d32f4ed3269d.htm
---
# Autodesk.Revit.DB.CurtainGridSetIterator.Reset Method

Bring the iterator back to the start of the set.

## Syntax (C#)
```csharp
public virtual void Reset()
```

## Remarks
The Reset method will return the iterator back to the start of the set in line with the definition of IEnumerator. Note that you must call MoveNext before the first item can be accessed via the Current property.

