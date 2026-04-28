---
kind: method
id: M:Autodesk.Revit.DB.GeomCombinationSetIterator.Reset
source: html/2846aed9-75dc-5146-766d-cd844e48c835.htm
---
# Autodesk.Revit.DB.GeomCombinationSetIterator.Reset Method

Bring the iterator back to the start of the set.

## Syntax (C#)
```csharp
public virtual void Reset()
```

## Remarks
The Reset method will return the iterator back to the start of the set in line with the definition of IEnumerator. Note that you must call MoveNext before the first item can be accessed via the Current property.

