---
kind: method
id: M:Autodesk.Revit.DB.CategorySetIterator.Reset
source: html/ea65f486-8223-ed66-c1e8-9e713e78aa42.htm
---
# Autodesk.Revit.DB.CategorySetIterator.Reset Method

Bring the iterator back to the start of the set.

## Syntax (C#)
```csharp
public virtual void Reset()
```

## Remarks
The Reset method will return the iterator back to the start of the set in line with the definition of IEnumerator. Note that you must call MoveNext before the first item can be accessed via the Current property.

