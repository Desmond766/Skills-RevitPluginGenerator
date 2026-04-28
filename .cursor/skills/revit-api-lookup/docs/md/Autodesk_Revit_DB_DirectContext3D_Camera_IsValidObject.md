---
kind: property
id: P:Autodesk.Revit.DB.DirectContext3D.Camera.IsValidObject
source: html/0ec6f5ea-a720-2188-07a8-3f7437e3e8fe.htm
---
# Autodesk.Revit.DB.DirectContext3D.Camera.IsValidObject Property

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

