---
kind: property
id: P:Autodesk.Revit.DB.Lighting.LightGroupManager.IsValidObject
source: html/50106c3f-db36-e0a1-45e0-f425c96460c3.htm
---
# Autodesk.Revit.DB.Lighting.LightGroupManager.IsValidObject Property

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

