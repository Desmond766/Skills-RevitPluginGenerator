---
kind: property
id: P:Autodesk.Revit.DB.TransformWithBoundary.IsValidObject
source: html/e79950d2-d0c4-5579-23e1-637d2ea17257.htm
---
# Autodesk.Revit.DB.TransformWithBoundary.IsValidObject Property

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

