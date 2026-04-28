---
kind: method
id: M:Autodesk.Revit.DB.EdgeArrayArrayIterator.Reset
source: html/4d1e9b75-91b1-b1e0-2248-4b86cbf86414.htm
---
# Autodesk.Revit.DB.EdgeArrayArrayIterator.Reset Method

Bring the iterator back to the start of the array.

## Syntax (C#)
```csharp
public virtual void Reset()
```

## Remarks
The Reset method will return the iterator back to the start of the array in line with the definition of IEnumerator. Note that you must call MoveNext before the first item can be accessed via the Current property.

