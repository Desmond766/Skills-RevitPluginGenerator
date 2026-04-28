---
kind: property
id: P:Autodesk.Revit.DB.Lighting.LightGroup.IsValidObject
source: html/2731a4bd-dfb3-029c-315d-6dda31d4c0db.htm
---
# Autodesk.Revit.DB.Lighting.LightGroup.IsValidObject Property

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

