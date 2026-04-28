---
kind: method
id: M:Autodesk.Revit.UI.Mechanical.DuctFittingAndAccessoryPressureDropUIDataItem.GetEntity
source: html/130d98d0-eef1-c442-c88b-e42b123e4c00.htm
---
# Autodesk.Revit.UI.Mechanical.DuctFittingAndAccessoryPressureDropUIDataItem.GetEntity Method

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

