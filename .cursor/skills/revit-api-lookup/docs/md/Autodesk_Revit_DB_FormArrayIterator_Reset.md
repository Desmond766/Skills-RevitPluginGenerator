---
kind: method
id: M:Autodesk.Revit.DB.FormArrayIterator.Reset
source: html/fe4fa42d-e258-13af-2896-d726dec14953.htm
---
# Autodesk.Revit.DB.FormArrayIterator.Reset Method

Bring the iterator back to the start of the array.

## Syntax (C#)
```csharp
public virtual void Reset()
```

## Remarks
The Reset method will return the iterator back to the start of the array in line with the definition of IEnumerator. Note that you must call MoveNext before the first item can be accessed via the Current property.

