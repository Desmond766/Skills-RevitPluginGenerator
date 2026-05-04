---
kind: property
id: P:Autodesk.Revit.DB.SolidGeometryOptions.IsValidObject
source: html/f69a31c7-1783-500e-548e-4a76c88c1ff2.htm
---
# Autodesk.Revit.DB.SolidGeometryOptions.IsValidObject Property

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

