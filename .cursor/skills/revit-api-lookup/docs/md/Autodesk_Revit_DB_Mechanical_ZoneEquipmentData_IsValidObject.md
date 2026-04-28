---
kind: property
id: P:Autodesk.Revit.DB.Mechanical.ZoneEquipmentData.IsValidObject
source: html/6c66d99c-89da-7f33-a256-2d2a7b51685f.htm
---
# Autodesk.Revit.DB.Mechanical.ZoneEquipmentData.IsValidObject Property

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

