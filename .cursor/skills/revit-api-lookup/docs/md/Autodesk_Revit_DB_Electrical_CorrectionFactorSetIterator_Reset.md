---
kind: method
id: M:Autodesk.Revit.DB.Electrical.CorrectionFactorSetIterator.Reset
source: html/4cc68279-2720-952b-dc7c-bee41cd220cf.htm
---
# Autodesk.Revit.DB.Electrical.CorrectionFactorSetIterator.Reset Method

Bring the iterator back to the start of the set.

## Syntax (C#)
```csharp
public virtual void Reset()
```

## Remarks
The Reset method will return the iterator back to the start of the set in line with the definition of IEnumerator. Note that you must call MoveNext before the first item can be accessed via the Current property.

