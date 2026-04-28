---
kind: property
id: P:Autodesk.Revit.DB.PolylineSegments.IsValidObject
source: html/a6054dce-28b6-d92d-fb81-4539f3065f45.htm
---
# Autodesk.Revit.DB.PolylineSegments.IsValidObject Property

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

