---
kind: method
id: M:Autodesk.Revit.DB.SlabShapeVertexArrayIterator.Reset
source: html/a4c39de0-4adf-4e5d-a083-840705b10015.htm
---
# Autodesk.Revit.DB.SlabShapeVertexArrayIterator.Reset Method

Bring the iterator back to the start of the array.

## Syntax (C#)
```csharp
public virtual void Reset()
```

## Remarks
The Reset method will return the iterator back to the start of the array in line with the definition of IEnumerator. Note that you must call MoveNext before the first item can be accessed via the Current property.

