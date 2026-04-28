---
kind: method
id: M:Autodesk.Revit.DB.ReferencePointArrayIterator.Reset
source: html/1f5ae73d-3b67-c8b3-ee5d-9b42a4f80f36.htm
---
# Autodesk.Revit.DB.ReferencePointArrayIterator.Reset Method

Bring the iterator back to the start of the array.

## Syntax (C#)
```csharp
public virtual void Reset()
```

## Remarks
The Reset method will return the iterator back to the start of the array in line with the definition of IEnumerator. Note that you must call MoveNext before the first item can be accessed via the Current property.

