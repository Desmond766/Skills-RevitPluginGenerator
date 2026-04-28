---
kind: method
id: M:Autodesk.Revit.DB.MullionTypeSetIterator.Reset
source: html/e668eb79-4ee3-ceb0-c782-5ecc805c3a0a.htm
---
# Autodesk.Revit.DB.MullionTypeSetIterator.Reset Method

Bring the iterator back to the start of the set.

## Syntax (C#)
```csharp
public virtual void Reset()
```

## Remarks
The Reset method will return the iterator back to the start of the set in line with the definition of IEnumerator. Note that you must call MoveNext before the first item can be accessed via the Current property.

