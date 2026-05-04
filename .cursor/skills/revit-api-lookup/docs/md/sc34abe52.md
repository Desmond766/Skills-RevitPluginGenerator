---
kind: property
id: P:Autodesk.Revit.DB.MassInstanceUtils.IsValidObject
source: html/b9a91cb3-89ca-14f2-bf3c-be79db05736b.htm
---
# Autodesk.Revit.DB.MassInstanceUtils.IsValidObject Property

Specifies whether the .NET object represents a valid Revit entity.

## Syntax (C#)
```csharp
public bool IsValidObject { get; }
```

## Returns
True if the API object holds a valid Revit native object, false otherwise.

## Remarks
If the corresponding Revit native object is destroyed, or creation of the corresponding object is undone,
 a managed API object containing it is no longer valid. API methods cannot be called on invalidated wrapper objects.

