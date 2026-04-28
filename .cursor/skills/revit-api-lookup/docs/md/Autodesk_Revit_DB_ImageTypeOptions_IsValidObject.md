---
kind: property
id: P:Autodesk.Revit.DB.ImageTypeOptions.IsValidObject
source: html/d6fccbef-3786-a1ae-cd60-0a54e9ea60e6.htm
---
# Autodesk.Revit.DB.ImageTypeOptions.IsValidObject Property

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

