---
kind: method
id: M:Autodesk.Revit.DB.Plumbing.PipeFittingAndAccessoryData.GetEntity
source: html/8fbbfc26-4995-ae39-f25d-5020635f9161.htm
---
# Autodesk.Revit.DB.Plumbing.PipeFittingAndAccessoryData.GetEntity Method

Returns an Entity of the Schema of the serverGUID.

## Syntax (C#)
```csharp
public Entity GetEntity()
```

## Returns
The Entity.

## Remarks
The Entity that is returned is a copy of the stored data (with copy-on-write optimization).
 Modifying it is allowed (even with restricted write), but to save your changes you must call SetEntity.

