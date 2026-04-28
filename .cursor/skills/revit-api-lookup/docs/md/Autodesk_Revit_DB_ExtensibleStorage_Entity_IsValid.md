---
kind: method
id: M:Autodesk.Revit.DB.ExtensibleStorage.Entity.IsValid
source: html/80267c39-5a68-d120-425a-835efbeb9b61.htm
---
# Autodesk.Revit.DB.ExtensibleStorage.Entity.IsValid Method

Checks whether this Entity has a live Schema corresponding to it.

## Syntax (C#)
```csharp
public bool IsValid()
```

## Returns
True if the Entity is valid.

## Remarks
Invalid entities may be used as token values. E.g., setting an invalid subentity
 is equivalent to deleting the stored one.

