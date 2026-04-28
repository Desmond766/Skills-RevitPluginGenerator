---
kind: method
id: M:Autodesk.Revit.DB.DefinitionBindingMapIterator.Reset
source: html/4acbd7fd-dbc2-16e8-3207-629774255b78.htm
---
# Autodesk.Revit.DB.DefinitionBindingMapIterator.Reset Method

Bring the iterator back to the start of the map.

## Syntax (C#)
```csharp
public virtual void Reset()
```

## Remarks
The Reset method will return the iterator back to the start of the map in line with the definition of IEnumerator. Note that you must call MoveNext before the first item can be accessed via the Current property.

