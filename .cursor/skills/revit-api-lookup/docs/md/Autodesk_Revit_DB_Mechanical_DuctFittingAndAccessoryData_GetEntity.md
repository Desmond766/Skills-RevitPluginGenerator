---
kind: method
id: M:Autodesk.Revit.DB.Mechanical.DuctFittingAndAccessoryData.GetEntity
source: html/c1e1344a-74d7-fd84-877f-e4513270e61c.htm
---
# Autodesk.Revit.DB.Mechanical.DuctFittingAndAccessoryData.GetEntity Method

Returns an Entity of the Schema of the serverGUID.
 or an invalid entity otherwise.

## Syntax (C#)
```csharp
public Entity GetEntity()
```

## Returns
The Entity.

## Remarks
The Entity that is returned is a copy of the stored data (with copy-on-write optimization).
 Modifying it is allowed (even with restricted write), but to save your changes you must call SetEntity.

