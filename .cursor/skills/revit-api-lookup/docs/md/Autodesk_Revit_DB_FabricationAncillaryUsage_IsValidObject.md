---
kind: property
id: P:Autodesk.Revit.DB.FabricationAncillaryUsage.IsValidObject
source: html/7a945110-3ab4-c822-a72e-2ef89be9c4cd.htm
---
# Autodesk.Revit.DB.FabricationAncillaryUsage.IsValidObject Property

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

