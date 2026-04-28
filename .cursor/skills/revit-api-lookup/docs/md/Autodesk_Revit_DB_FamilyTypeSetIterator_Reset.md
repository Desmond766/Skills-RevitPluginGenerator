---
kind: method
id: M:Autodesk.Revit.DB.FamilyTypeSetIterator.Reset
source: html/8d6b0de5-8526-38ae-6502-b0033bc728e6.htm
---
# Autodesk.Revit.DB.FamilyTypeSetIterator.Reset Method

Bring the iterator back to the start of the set.

## Syntax (C#)
```csharp
public virtual void Reset()
```

## Remarks
The Reset method will return the iterator back to the start of the set in line with the definition of IEnumerator. Note that you must call MoveNext before the first item can be accessed via the Current property.

