---
kind: method
id: M:Autodesk.Revit.DB.CurveArrayIterator.Reset
source: html/776dc4a2-4607-0f49-e0ae-6ea579798544.htm
---
# Autodesk.Revit.DB.CurveArrayIterator.Reset Method

Bring the iterator back to the start of the array.

## Syntax (C#)
```csharp
public virtual void Reset()
```

## Remarks
The Reset method will return the iterator back to the start of the array in line with the definition of IEnumerator. Note that you must call MoveNext before the first item can be accessed via the Current property.

