---
kind: method
id: M:Autodesk.Revit.DB.ParameterSetIterator.Reset
source: html/f99fe3b4-dde3-c557-adf2-d986cb95301e.htm
---
# Autodesk.Revit.DB.ParameterSetIterator.Reset Method

Bring the iterator back to the start of the set.

## Syntax (C#)
```csharp
public virtual void Reset()
```

## Remarks
The Reset method will return the iterator back to the start of the set in line with the definition of IEnumerator. Note that you must call MoveNext before the first item can be accessed via the Current property.

