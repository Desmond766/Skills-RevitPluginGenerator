---
kind: property
id: P:Autodesk.Revit.DB.FamilyThermalProperties.IsValidObject
source: html/9e7952d4-a28f-0dd9-5357-30c5dbf25748.htm
---
# Autodesk.Revit.DB.FamilyThermalProperties.IsValidObject Property

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

