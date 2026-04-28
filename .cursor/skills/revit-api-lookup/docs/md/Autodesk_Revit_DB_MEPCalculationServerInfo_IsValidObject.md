---
kind: property
id: P:Autodesk.Revit.DB.MEPCalculationServerInfo.IsValidObject
source: html/98ca0a2e-06d1-eb09-db76-71338869a91e.htm
---
# Autodesk.Revit.DB.MEPCalculationServerInfo.IsValidObject Property

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

