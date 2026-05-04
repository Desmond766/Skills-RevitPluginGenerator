---
kind: property
id: P:Autodesk.Revit.DB.Lighting.LightType.IsValidObject
source: html/5b5f1e73-8f56-538d-138d-05d7143bb055.htm
---
# Autodesk.Revit.DB.Lighting.LightType.IsValidObject Property

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

