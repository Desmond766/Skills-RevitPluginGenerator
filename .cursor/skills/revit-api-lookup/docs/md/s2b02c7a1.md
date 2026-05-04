---
kind: property
id: P:Autodesk.Revit.DB.ThermalProperties.IsValidObject
source: html/3946b7c9-11d6-31f5-bee2-be16cb86d525.htm
---
# Autodesk.Revit.DB.ThermalProperties.IsValidObject Property

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

