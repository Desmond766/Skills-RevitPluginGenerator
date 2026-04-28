---
kind: property
id: P:Autodesk.Revit.DB.FabricationConnectorInfo.IsValidObject
source: html/797ca15b-edbf-ba3e-35cc-bc949145f03d.htm
---
# Autodesk.Revit.DB.FabricationConnectorInfo.IsValidObject Property

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

