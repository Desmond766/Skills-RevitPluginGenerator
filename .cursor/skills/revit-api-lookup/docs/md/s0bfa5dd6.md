---
kind: method
id: M:Autodesk.Revit.DB.ModelCurveArrayIterator.Reset
source: html/631d0654-e5ef-5267-0ce7-70cbdd42dfe6.htm
---
# Autodesk.Revit.DB.ModelCurveArrayIterator.Reset Method

Bring the iterator back to the start of the array.

## Syntax (C#)
```csharp
public virtual void Reset()
```

## Remarks
The Reset method will return the iterator back to the start of the array in line with the definition of IEnumerator. Note that you must call MoveNext before the first item can be accessed via the Current property.

