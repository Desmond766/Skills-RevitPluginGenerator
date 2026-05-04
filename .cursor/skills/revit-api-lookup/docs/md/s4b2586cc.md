---
kind: property
id: P:Autodesk.Revit.DB.FabricationServiceButton.IsValidObject
source: html/ea34aa2d-7ba8-4689-2430-d0b287c5d77e.htm
---
# Autodesk.Revit.DB.FabricationServiceButton.IsValidObject Property

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

