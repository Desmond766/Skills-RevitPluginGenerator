---
kind: property
id: P:Autodesk.Revit.DB.RenderingSettings.IsValidObject
source: html/34c7e7ab-489c-7f71-e5d1-c43a5e75183b.htm
---
# Autodesk.Revit.DB.RenderingSettings.IsValidObject Property

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

