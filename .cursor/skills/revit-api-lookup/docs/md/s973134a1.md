---
kind: property
id: P:Autodesk.Revit.DB.Electrical.AnalyticalDistributionNodePropertyData.IsValidObject
source: html/d3767f0c-ecb2-e6bc-3b6f-0a65f71204b2.htm
---
# Autodesk.Revit.DB.Electrical.AnalyticalDistributionNodePropertyData.IsValidObject Property

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

