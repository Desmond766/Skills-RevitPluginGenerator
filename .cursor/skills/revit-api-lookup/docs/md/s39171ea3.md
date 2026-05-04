---
kind: property
id: P:Autodesk.Revit.DB.IFC.IFCGeometryInfo.IsValidObject
source: html/6d72146a-69ee-7ed9-a0b1-0aeb70e2a883.htm
---
# Autodesk.Revit.DB.IFC.IFCGeometryInfo.IsValidObject Property

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

