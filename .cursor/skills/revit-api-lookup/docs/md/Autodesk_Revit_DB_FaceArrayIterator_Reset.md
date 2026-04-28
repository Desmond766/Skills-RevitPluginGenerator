---
kind: method
id: M:Autodesk.Revit.DB.FaceArrayIterator.Reset
source: html/8031b92d-d8da-4c0b-a2cd-383d98d07428.htm
---
# Autodesk.Revit.DB.FaceArrayIterator.Reset Method

Bring the iterator back to the start of the array.

## Syntax (C#)
```csharp
public virtual void Reset()
```

## Remarks
The Reset method will return the iterator back to the start of the array in line with the definition of IEnumerator. Note that you must call MoveNext before the first item can be accessed via the Current property.

