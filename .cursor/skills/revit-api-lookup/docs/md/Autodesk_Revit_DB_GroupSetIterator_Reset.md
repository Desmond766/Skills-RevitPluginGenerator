---
kind: method
id: M:Autodesk.Revit.DB.GroupSetIterator.Reset
source: html/0b8ae230-534d-3a56-5b93-e0420aaa295a.htm
---
# Autodesk.Revit.DB.GroupSetIterator.Reset Method

Bring the iterator back to the start of the set.

## Syntax (C#)
```csharp
public virtual void Reset()
```

## Remarks
The Reset method will return the iterator back to the start of the set in line with the definition of IEnumerator. Note that you must call MoveNext before the first item can be accessed via the Current property.

