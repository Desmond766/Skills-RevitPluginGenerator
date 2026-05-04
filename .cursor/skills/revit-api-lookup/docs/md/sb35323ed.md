---
kind: method
id: M:Autodesk.Revit.DB.Mechanical.MEPBuildingConstructionSetIterator.Reset
source: html/a6246e09-4942-0c4d-a055-d20f16b0fff7.htm
---
# Autodesk.Revit.DB.Mechanical.MEPBuildingConstructionSetIterator.Reset Method

Bring the iterator back to the start of the set.

## Syntax (C#)
```csharp
public virtual void Reset()
```

## Remarks
The Reset method will return the iterator back to the start of the set in line with the definition of IEnumerator. Note that you must call MoveNext before the first item can be accessed via the Current property.

