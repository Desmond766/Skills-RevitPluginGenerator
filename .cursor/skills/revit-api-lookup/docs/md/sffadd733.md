---
kind: method
id: M:Autodesk.Revit.DB.ViewSetIterator.Reset
source: html/7c7670d3-90d4-fc7b-7553-e7a09e23b0c3.htm
---
# Autodesk.Revit.DB.ViewSetIterator.Reset Method

Bring the iterator back to the start of the set.

## Syntax (C#)
```csharp
public virtual void Reset()
```

## Remarks
The Reset method will return the iterator back to the start of the set in line with the definition of IEnumerator. Note that you must call MoveNext before the first item can be accessed via the Current property.

