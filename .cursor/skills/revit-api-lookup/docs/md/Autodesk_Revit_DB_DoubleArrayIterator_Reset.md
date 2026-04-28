---
kind: method
id: M:Autodesk.Revit.DB.DoubleArrayIterator.Reset
source: html/dddbe5e4-c4d2-b642-6c2c-a8750a5f369c.htm
---
# Autodesk.Revit.DB.DoubleArrayIterator.Reset Method

Bring the iterator back to the start of the array.

## Syntax (C#)
```csharp
public virtual void Reset()
```

## Remarks
The Reset method will return the iterator back to the start of the array in line with the definition of IEnumerator. Note that you must call MoveNext before the first item can be accessed via the Current property.

