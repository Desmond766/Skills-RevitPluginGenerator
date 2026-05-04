---
kind: property
id: P:Autodesk.Revit.DB.Lighting.LossFactor.IsValidObject
source: html/eac84ac8-d3e4-eb18-5f0c-c6c9da7ed5d4.htm
---
# Autodesk.Revit.DB.Lighting.LossFactor.IsValidObject Property

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

