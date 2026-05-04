---
kind: method
id: M:Autodesk.Revit.DB.Electrical.WireSizeSetIterator.Reset
source: html/a7eab35f-3454-8c89-6556-91d3698311b6.htm
---
# Autodesk.Revit.DB.Electrical.WireSizeSetIterator.Reset Method

Bring the iterator back to the start of the set.

## Syntax (C#)
```csharp
public virtual void Reset()
```

## Remarks
The Reset method will return the iterator back to the start of the set in line with the definition of IEnumerator. Note that you must call MoveNext before the first item can be accessed via the Current property.

