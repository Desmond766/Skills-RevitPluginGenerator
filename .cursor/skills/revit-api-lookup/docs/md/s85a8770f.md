---
kind: method
id: M:Autodesk.Revit.DB.Electrical.WireMaterialTypeSetIterator.Reset
source: html/fe4cc720-c2c5-504b-22bc-1b143f76d698.htm
---
# Autodesk.Revit.DB.Electrical.WireMaterialTypeSetIterator.Reset Method

Bring the iterator back to the start of the set.

## Syntax (C#)
```csharp
public virtual void Reset()
```

## Remarks
The Reset method will return the iterator back to the start of the set in line with the definition of IEnumerator. Note that you must call MoveNext before the first item can be accessed via the Current property.

