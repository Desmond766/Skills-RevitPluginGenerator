---
kind: method
id: M:Autodesk.Revit.DB.DocumentSetIterator.Reset
source: html/2ece579b-bb14-b237-7bfe-8cf2f4d52a09.htm
---
# Autodesk.Revit.DB.DocumentSetIterator.Reset Method

Bring the iterator back to the start of the set.

## Syntax (C#)
```csharp
public virtual void Reset()
```

## Remarks
The Reset method will return the iterator back to the start of the set in line with the definition of IEnumerator. Note that you must call MoveNext before the first item can be accessed via the Current property.

