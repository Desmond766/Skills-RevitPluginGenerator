---
kind: method
id: M:Autodesk.Revit.DB.PaperSizeSetIterator.Reset
source: html/fac3dfd7-1286-2638-539b-d84bd6476a1a.htm
---
# Autodesk.Revit.DB.PaperSizeSetIterator.Reset Method

Bring the iterator back to the start of the set.

## Syntax (C#)
```csharp
public virtual void Reset()
```

## Remarks
The Reset method will return the iterator back to the start of the set in line with the definition of IEnumerator. Note that you must call MoveNext before the first item can be accessed via the Current property.

