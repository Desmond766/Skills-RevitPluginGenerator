---
kind: method
id: M:Autodesk.Revit.DB.VertexIndexPairArrayIterator.Reset
source: html/49d7c4f5-7af4-dc6a-7930-24a4c80d1e36.htm
---
# Autodesk.Revit.DB.VertexIndexPairArrayIterator.Reset Method

Bring the iterator back to the start of the array.

## Syntax (C#)
```csharp
public virtual void Reset()
```

## Remarks
The Reset method will return the iterator back to the start of the array in line with the definition of IEnumerator. Note that you must call MoveNext before the first item can be accessed via the Current property.

