---
kind: method
id: M:Autodesk.Revit.UI.Plumbing.PipeFittingAndAccessoryPressureDropUIDataItem.GetEntity
source: html/2f04d05b-420e-04d3-60b9-85bb3a031346.htm
---
# Autodesk.Revit.UI.Plumbing.PipeFittingAndAccessoryPressureDropUIDataItem.GetEntity Method

Returns the entity set by UI server.
 or an invalid entity otherwise.

## Syntax (C#)
```csharp
public Entity GetEntity()
```

## Returns
The returned Entity.

## Remarks
The Entity that is returned is a copy of the stored data (with copy-on-write optimization).
 Modifying it is allowed (even with restricted write), but to save your changes you must call SetEntity.

