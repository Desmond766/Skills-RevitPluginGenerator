---
kind: method
id: M:Autodesk.Revit.DB.ModelCurveArrArrayIterator.Reset
source: html/c776ea83-22d4-b520-0992-8ea0adaa790f.htm
---
# Autodesk.Revit.DB.ModelCurveArrArrayIterator.Reset Method

Bring the iterator back to the start of the array.

## Syntax (C#)
```csharp
public virtual void Reset()
```

## Remarks
The Reset method will return the iterator back to the start of the array in line with the definition of IEnumerator. Note that you must call MoveNext before the first item can be accessed via the Current property.

