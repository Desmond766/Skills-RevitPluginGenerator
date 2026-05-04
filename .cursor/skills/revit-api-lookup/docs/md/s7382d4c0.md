---
kind: method
id: M:Autodesk.Revit.DB.CurveByPointsArrayIterator.Reset
source: html/ef41c8ef-0dbc-212f-f4b1-b3bc0cc252a4.htm
---
# Autodesk.Revit.DB.CurveByPointsArrayIterator.Reset Method

Bring the iterator back to the start of the array.

## Syntax (C#)
```csharp
public virtual void Reset()
```

## Remarks
The Reset method will return the iterator back to the start of the array in line with the definition of IEnumerator. Note that you must call MoveNext before the first item can be accessed via the Current property.

