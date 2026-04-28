---
kind: method
id: M:Autodesk.Revit.DB.ParameterMapIterator.Reset
source: html/7e803582-168d-e6fd-070e-71581bb8de1b.htm
---
# Autodesk.Revit.DB.ParameterMapIterator.Reset Method

Bring the iterator back to the start of the map.

## Syntax (C#)
```csharp
public virtual void Reset()
```

## Remarks
The Reset method will return the iterator back to the start of the map in line with the definition of IEnumerator. Note that you must call MoveNext before the first item can be accessed via the Current property.

