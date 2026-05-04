---
kind: property
id: P:Autodesk.Revit.DB.DirectContext3D.DirectContext3DHandleSettings.IsValidObject
source: html/3aa923fb-a314-c5fd-c28d-d6aefe97f889.htm
---
# Autodesk.Revit.DB.DirectContext3D.DirectContext3DHandleSettings.IsValidObject Property

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

