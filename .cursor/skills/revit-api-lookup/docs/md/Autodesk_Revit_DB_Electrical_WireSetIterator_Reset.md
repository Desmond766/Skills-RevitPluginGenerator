---
kind: method
id: M:Autodesk.Revit.DB.Electrical.WireSetIterator.Reset
source: html/7b1fd9b3-330e-6f52-4bb1-caf463771e9d.htm
---
# Autodesk.Revit.DB.Electrical.WireSetIterator.Reset Method

Bring the iterator back to the start of the set.

## Syntax (C#)
```csharp
public virtual void Reset()
```

## Remarks
The Reset method will return the iterator back to the start of the set in line with the definition of IEnumerator. Note that you must call MoveNext before the first item can be accessed via the Current property.

