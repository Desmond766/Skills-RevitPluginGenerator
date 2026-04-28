---
kind: property
id: P:Autodesk.Revit.DB.ExternalResourceServerExtensions.IsValidObject
source: html/398b0559-6c4e-5a63-73a4-627c43cf3d90.htm
---
# Autodesk.Revit.DB.ExternalResourceServerExtensions.IsValidObject Property

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

