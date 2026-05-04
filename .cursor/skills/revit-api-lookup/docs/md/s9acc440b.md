---
kind: method
id: M:Autodesk.Revit.DB.Electrical.VoltageTypeSetIterator.Reset
source: html/eaab66ae-6486-011d-9f48-131e6a620fa6.htm
---
# Autodesk.Revit.DB.Electrical.VoltageTypeSetIterator.Reset Method

Bring the iterator back to the start of the set.

## Syntax (C#)
```csharp
public virtual void Reset()
```

## Remarks
The Reset method will return the iterator back to the start of the set in line with the definition of IEnumerator. Note that you must call MoveNext before the first item can be accessed via the Current property.

