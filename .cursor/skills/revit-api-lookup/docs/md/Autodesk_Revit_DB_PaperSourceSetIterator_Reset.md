---
kind: method
id: M:Autodesk.Revit.DB.PaperSourceSetIterator.Reset
source: html/56a267a8-4183-152f-56b6-70671f0f04ce.htm
---
# Autodesk.Revit.DB.PaperSourceSetIterator.Reset Method

Bring the iterator back to the start of the set.

## Syntax (C#)
```csharp
public virtual void Reset()
```

## Remarks
The Reset method will return the iterator back to the start of the set in line with the definition of IEnumerator. Note that you must call MoveNext before the first item can be accessed via the Current property.

