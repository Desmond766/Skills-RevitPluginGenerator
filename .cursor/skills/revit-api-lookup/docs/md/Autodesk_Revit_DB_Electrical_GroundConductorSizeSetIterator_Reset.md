---
kind: method
id: M:Autodesk.Revit.DB.Electrical.GroundConductorSizeSetIterator.Reset
source: html/d047ad79-2348-72f0-1f67-75e060603e38.htm
---
# Autodesk.Revit.DB.Electrical.GroundConductorSizeSetIterator.Reset Method

Bring the iterator back to the start of the set.

## Syntax (C#)
```csharp
public virtual void Reset()
```

## Remarks
The Reset method will return the iterator back to the start of the set in line with the definition of IEnumerator. Note that you must call MoveNext before the first item can be accessed via the Current property.

