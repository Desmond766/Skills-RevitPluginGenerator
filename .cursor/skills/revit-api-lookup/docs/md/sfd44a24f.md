---
kind: method
id: M:Autodesk.Revit.DB.FamilyParameterSetIterator.Reset
source: html/36dc444e-2b89-fe32-233a-c70b2b31a606.htm
---
# Autodesk.Revit.DB.FamilyParameterSetIterator.Reset Method

Bring the iterator back to the start of the set.

## Syntax (C#)
```csharp
public virtual void Reset()
```

## Remarks
The Reset method will return the iterator back to the start of the set in line with the definition of IEnumerator. Note that you must call MoveNext before the first item can be accessed via the Current property.

