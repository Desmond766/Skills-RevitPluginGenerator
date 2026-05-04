---
kind: method
id: M:Autodesk.Revit.DB.Mechanical.SpaceSetIterator.Reset
source: html/54ffff24-e84c-d381-9cfe-4eb85e386349.htm
---
# Autodesk.Revit.DB.Mechanical.SpaceSetIterator.Reset Method

Bring the iterator back to the start of the set.

## Syntax (C#)
```csharp
public virtual void Reset()
```

## Remarks
The Reset method will return the iterator back to the start of the set in line with the definition of IEnumerator. Note that you must call MoveNext before the first item can be accessed via the Current property.

