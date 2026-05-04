---
kind: property
id: P:Autodesk.Revit.DB.Lighting.LightShape.IsValidObject
source: html/114aa517-ec9d-25a8-7b03-213d1458ba95.htm
---
# Autodesk.Revit.DB.Lighting.LightShape.IsValidObject Property

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

