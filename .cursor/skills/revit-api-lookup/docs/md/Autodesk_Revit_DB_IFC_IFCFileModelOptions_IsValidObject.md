---
kind: property
id: P:Autodesk.Revit.DB.IFC.IFCFileModelOptions.IsValidObject
source: html/f3d0b9ef-2049-33bd-f83f-ae7441bb87dd.htm
---
# Autodesk.Revit.DB.IFC.IFCFileModelOptions.IsValidObject Property

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

