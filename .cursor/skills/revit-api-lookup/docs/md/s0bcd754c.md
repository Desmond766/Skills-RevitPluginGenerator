---
kind: property
id: P:Autodesk.Revit.DB.Analysis.MEPNetworkSegmentData.IsValidObject
source: html/f1485ad6-94df-54fa-bea4-aff6b4db1252.htm
---
# Autodesk.Revit.DB.Analysis.MEPNetworkSegmentData.IsValidObject Property

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

