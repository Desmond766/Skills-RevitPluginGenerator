---
kind: property
id: P:Autodesk.Revit.DB.ThermalAsset.IsValidObject
source: html/1e7f2abe-ffa7-0a0e-5620-b9daee93f06e.htm
---
# Autodesk.Revit.DB.ThermalAsset.IsValidObject Property

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

