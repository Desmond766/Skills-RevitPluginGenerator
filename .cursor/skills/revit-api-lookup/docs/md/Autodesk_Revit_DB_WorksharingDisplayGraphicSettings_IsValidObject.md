---
kind: property
id: P:Autodesk.Revit.DB.WorksharingDisplayGraphicSettings.IsValidObject
source: html/7f52262d-f6ce-c01d-5046-31362b6a8c91.htm
---
# Autodesk.Revit.DB.WorksharingDisplayGraphicSettings.IsValidObject Property

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

