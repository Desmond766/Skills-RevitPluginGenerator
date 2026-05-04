---
kind: method
id: M:Autodesk.Revit.DB.ElementArrayIterator.Reset
source: html/e34f6a06-d8be-8fdd-7a30-29f098fc25f7.htm
---
# Autodesk.Revit.DB.ElementArrayIterator.Reset Method

Bring the iterator back to the start of the array.

## Syntax (C#)
```csharp
public virtual void Reset()
```

## Remarks
The Reset method will return the iterator back to the start of the array in line with the definition of IEnumerator. Note that you must call MoveNext before the first item can be accessed via the Current property.

