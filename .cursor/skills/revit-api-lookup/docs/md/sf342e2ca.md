---
kind: property
id: P:Autodesk.Revit.DB.Analysis.MEPNetworkSegmentId.IsValidObject
source: html/84a96d2d-42c9-fe23-e926-8c83c51e7ba5.htm
---
# Autodesk.Revit.DB.Analysis.MEPNetworkSegmentId.IsValidObject Property

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

