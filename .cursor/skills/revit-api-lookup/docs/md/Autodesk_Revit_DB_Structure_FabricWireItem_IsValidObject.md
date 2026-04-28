---
kind: property
id: P:Autodesk.Revit.DB.Structure.FabricWireItem.IsValidObject
source: html/f8e05b02-4d23-a1e5-139b-ec3d5d8035ee.htm
---
# Autodesk.Revit.DB.Structure.FabricWireItem.IsValidObject Property

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

