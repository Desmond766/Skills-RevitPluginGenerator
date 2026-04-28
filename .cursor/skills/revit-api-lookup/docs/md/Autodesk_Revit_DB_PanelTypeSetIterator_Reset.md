---
kind: method
id: M:Autodesk.Revit.DB.PanelTypeSetIterator.Reset
source: html/a09a9fd0-0c5b-9f8d-ade1-330a0902fe30.htm
---
# Autodesk.Revit.DB.PanelTypeSetIterator.Reset Method

Bring the iterator back to the start of the set.

## Syntax (C#)
```csharp
public virtual void Reset()
```

## Remarks
The Reset method will return the iterator back to the start of the set in line with the definition of IEnumerator. Note that you must call MoveNext before the first item can be accessed via the Current property.

