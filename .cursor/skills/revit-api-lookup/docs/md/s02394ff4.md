---
kind: property
id: P:Autodesk.Revit.DB.RenderingQualitySettings.IsValidObject
source: html/62daf281-0a7c-a705-48d4-5e858e4e9f64.htm
---
# Autodesk.Revit.DB.RenderingQualitySettings.IsValidObject Property

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

