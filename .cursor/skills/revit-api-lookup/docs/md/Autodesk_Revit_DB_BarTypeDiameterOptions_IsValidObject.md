---
kind: property
id: P:Autodesk.Revit.DB.BarTypeDiameterOptions.IsValidObject
source: html/728a5d45-14f2-d42c-2f5e-c7fd0955ba9f.htm
---
# Autodesk.Revit.DB.BarTypeDiameterOptions.IsValidObject Property

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

