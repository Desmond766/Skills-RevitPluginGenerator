---
kind: property
id: P:Autodesk.Revit.DB.Lighting.LightFamily.IsValidObject
source: html/a0edb24e-86f7-3d30-cea5-6c835d5d74af.htm
---
# Autodesk.Revit.DB.Lighting.LightFamily.IsValidObject Property

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

