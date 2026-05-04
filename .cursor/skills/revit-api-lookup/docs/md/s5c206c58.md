---
kind: property
id: P:Autodesk.Revit.DB.DirectContext3D.ClipPlane.IsValidObject
source: html/6ab28410-dd73-c24b-a4b1-1ae2e57a0f75.htm
---
# Autodesk.Revit.DB.DirectContext3D.ClipPlane.IsValidObject Property

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

