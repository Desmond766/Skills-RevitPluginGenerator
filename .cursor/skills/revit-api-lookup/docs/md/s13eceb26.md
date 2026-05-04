---
kind: property
id: P:Autodesk.Revit.DB.FabricationService.IsValidObject
source: html/de24cfdf-2390-854d-d701-a6185939a40b.htm
---
# Autodesk.Revit.DB.FabricationService.IsValidObject Property

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

