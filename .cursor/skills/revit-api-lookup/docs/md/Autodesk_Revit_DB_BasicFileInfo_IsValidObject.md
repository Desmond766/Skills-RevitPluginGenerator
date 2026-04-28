---
kind: property
id: P:Autodesk.Revit.DB.BasicFileInfo.IsValidObject
source: html/36688ac8-26a4-51d3-4cac-314e95fcab2d.htm
---
# Autodesk.Revit.DB.BasicFileInfo.IsValidObject Property

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

