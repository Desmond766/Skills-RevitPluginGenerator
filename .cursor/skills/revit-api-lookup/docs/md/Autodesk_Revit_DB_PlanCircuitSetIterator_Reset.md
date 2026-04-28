---
kind: method
id: M:Autodesk.Revit.DB.PlanCircuitSetIterator.Reset
source: html/ad6df922-a55e-a7af-72d6-a2efb596f31e.htm
---
# Autodesk.Revit.DB.PlanCircuitSetIterator.Reset Method

Bring the iterator back to the start of the set.

## Syntax (C#)
```csharp
public virtual void Reset()
```

## Remarks
The Reset method will return the iterator back to the start of the set in line with the definition of IEnumerator. Note that you must call MoveNext before the first item can be accessed via the Current property.

