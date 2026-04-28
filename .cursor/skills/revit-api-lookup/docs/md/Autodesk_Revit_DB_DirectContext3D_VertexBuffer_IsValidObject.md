---
kind: property
id: P:Autodesk.Revit.DB.DirectContext3D.VertexBuffer.IsValidObject
source: html/90f7d182-95df-673e-4a24-f2111ff3c6cf.htm
---
# Autodesk.Revit.DB.DirectContext3D.VertexBuffer.IsValidObject Property

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

