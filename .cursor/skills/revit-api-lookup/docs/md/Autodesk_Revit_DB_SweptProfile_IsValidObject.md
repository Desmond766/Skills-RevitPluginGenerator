---
kind: property
id: P:Autodesk.Revit.DB.SweptProfile.IsValidObject
source: html/439e8e00-aaf1-12e5-af2d-e0ee1b990e79.htm
---
# Autodesk.Revit.DB.SweptProfile.IsValidObject Property

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

