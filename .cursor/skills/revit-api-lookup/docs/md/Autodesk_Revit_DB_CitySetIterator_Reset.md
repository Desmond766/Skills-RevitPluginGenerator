---
kind: method
id: M:Autodesk.Revit.DB.CitySetIterator.Reset
source: html/a01a54a1-1e54-f6eb-da49-475b07397042.htm
---
# Autodesk.Revit.DB.CitySetIterator.Reset Method

Bring the iterator back to the start of the set.

## Syntax (C#)
```csharp
public virtual void Reset()
```

## Remarks
The Reset method will return the iterator back to the start of the set in line with the definition of IEnumerator. Note that you must call MoveNext before the first item can be accessed via the Current property.

