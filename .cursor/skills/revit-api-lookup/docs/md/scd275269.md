---
kind: method
id: M:Autodesk.Revit.DB.ConnectorSetIterator.Reset
source: html/5dea0f57-30ec-fc0a-1625-b0a8261a8c44.htm
---
# Autodesk.Revit.DB.ConnectorSetIterator.Reset Method

Bring the iterator back to the start of the set.

## Syntax (C#)
```csharp
public virtual void Reset()
```

## Remarks
The Reset method will return the iterator back to the start of the set in line with the definition of IEnumerator. Note that you must call MoveNext before the first item can be accessed via the Current property.

