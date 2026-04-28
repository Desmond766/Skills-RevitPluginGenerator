---
kind: method
id: M:Autodesk.Revit.DB.CategoryNameMapIterator.Reset
source: html/e4ab8552-674e-7c27-3845-8731ed06fad5.htm
---
# Autodesk.Revit.DB.CategoryNameMapIterator.Reset Method

Bring the iterator back to the start of the map.

## Syntax (C#)
```csharp
public virtual void Reset()
```

## Remarks
The Reset method will return the iterator back to the start of the map in line with the definition of IEnumerator. Note that you must call MoveNext before the first item can be accessed via the Current property.

