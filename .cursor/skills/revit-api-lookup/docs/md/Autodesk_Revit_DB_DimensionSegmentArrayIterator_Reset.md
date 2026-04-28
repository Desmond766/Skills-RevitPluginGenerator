---
kind: method
id: M:Autodesk.Revit.DB.DimensionSegmentArrayIterator.Reset
source: html/a2aee92a-f16b-0e21-e529-06708edafffa.htm
---
# Autodesk.Revit.DB.DimensionSegmentArrayIterator.Reset Method

Bring the iterator back to the start of the array.

## Syntax (C#)
```csharp
public virtual void Reset()
```

## Remarks
The Reset method will return the iterator back to the start of the array in line with the definition of IEnumerator. Note that you must call MoveNext before the first item can be accessed via the Current property.

