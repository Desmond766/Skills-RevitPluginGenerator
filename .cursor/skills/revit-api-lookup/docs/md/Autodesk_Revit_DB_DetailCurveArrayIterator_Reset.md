---
kind: method
id: M:Autodesk.Revit.DB.DetailCurveArrayIterator.Reset
source: html/7962ea29-2421-5bbf-f50c-d56480fea5cb.htm
---
# Autodesk.Revit.DB.DetailCurveArrayIterator.Reset Method

Bring the iterator back to the start of the array.

## Syntax (C#)
```csharp
public virtual void Reset()
```

## Remarks
The Reset method will return the iterator back to the start of the array in line with the definition of IEnumerator. Note that you must call MoveNext before the first item can be accessed via the Current property.

