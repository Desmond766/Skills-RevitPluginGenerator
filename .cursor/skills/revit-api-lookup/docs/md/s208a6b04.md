---
kind: method
id: M:Autodesk.Revit.DB.ElementSetIterator.Reset
source: html/a5a62af8-5def-2634-2979-4baa5587315e.htm
---
# Autodesk.Revit.DB.ElementSetIterator.Reset Method

Bring the iterator back to the start of the set.

## Syntax (C#)
```csharp
public virtual void Reset()
```

## Remarks
The Reset method will return the iterator back to the start of the set in line with the definition of IEnumerator. Note that you must call MoveNext before the first item can be accessed via the Current property.

