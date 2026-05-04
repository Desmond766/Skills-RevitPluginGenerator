---
kind: property
id: P:Autodesk.Revit.DB.IFC.IFCConnectedWallData.IsValidObject
source: html/2a9e91ca-e13e-0068-13b3-5514e14bc1e1.htm
---
# Autodesk.Revit.DB.IFC.IFCConnectedWallData.IsValidObject Property

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

