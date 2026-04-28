---
kind: method
id: M:Autodesk.Revit.UI.ExternalApplicationArrayIterator.Reset
source: html/837b6372-4181-21c7-9f7d-cd6a2425eeda.htm
---
# Autodesk.Revit.UI.ExternalApplicationArrayIterator.Reset Method

Bring the iterator back to the start of the array.

## Syntax (C#)
```csharp
public virtual void Reset()
```

## Remarks
The Reset method will return the iterator back to the start of the array in line with the definition of IEnumerator. Note that you must call MoveNext before the first item can be accessed via the Current property.

