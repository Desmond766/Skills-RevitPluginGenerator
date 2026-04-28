---
kind: property
id: P:Autodesk.Revit.DB.IFC.RoofComponents.IsValidObject
source: html/8daf3421-64e7-5134-94e1-d3bdbfcd8e82.htm
---
# Autodesk.Revit.DB.IFC.RoofComponents.IsValidObject Property

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

