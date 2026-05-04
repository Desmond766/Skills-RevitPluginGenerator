---
kind: method
id: M:Autodesk.Revit.DB.Electrical.WireConduitTypeSetIterator.Reset
source: html/3d73a7f1-905c-59f4-bfcf-05bf7aa549ce.htm
---
# Autodesk.Revit.DB.Electrical.WireConduitTypeSetIterator.Reset Method

Bring the iterator back to the start of the set.

## Syntax (C#)
```csharp
public virtual void Reset()
```

## Remarks
The Reset method will return the iterator back to the start of the set in line with the definition of IEnumerator. Note that you must call MoveNext before the first item can be accessed via the Current property.

