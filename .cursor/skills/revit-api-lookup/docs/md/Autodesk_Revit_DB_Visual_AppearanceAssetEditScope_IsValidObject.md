---
kind: property
id: P:Autodesk.Revit.DB.Visual.AppearanceAssetEditScope.IsValidObject
source: html/7a2730a0-6e69-501f-97b5-4a80e36ad3c6.htm
---
# Autodesk.Revit.DB.Visual.AppearanceAssetEditScope.IsValidObject Property

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

