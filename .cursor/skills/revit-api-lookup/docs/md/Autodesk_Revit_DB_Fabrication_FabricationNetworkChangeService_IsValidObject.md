---
kind: property
id: P:Autodesk.Revit.DB.Fabrication.FabricationNetworkChangeService.IsValidObject
source: html/77837193-60c4-1bd5-fd55-eaf3c08a965d.htm
---
# Autodesk.Revit.DB.Fabrication.FabricationNetworkChangeService.IsValidObject Property

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

