---
kind: method
id: M:Autodesk.Revit.DB.CurveArrArrayIterator.Reset
source: html/0decce27-39ca-cd70-d690-cdc6227a269a.htm
---
# Autodesk.Revit.DB.CurveArrArrayIterator.Reset Method

Bring the iterator back to the start of the array.

## Syntax (C#)
```csharp
public virtual void Reset()
```

## Remarks
The Reset method will return the iterator back to the start of the array in line with the definition of IEnumerator. Note that you must call MoveNext before the first item can be accessed via the Current property.

