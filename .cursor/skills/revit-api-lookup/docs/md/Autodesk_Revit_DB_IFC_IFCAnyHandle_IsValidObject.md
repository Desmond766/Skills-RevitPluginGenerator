---
kind: property
id: P:Autodesk.Revit.DB.IFC.IFCAnyHandle.IsValidObject
source: html/0f41edbb-7a4f-d77b-adc8-e756985dafb7.htm
---
# Autodesk.Revit.DB.IFC.IFCAnyHandle.IsValidObject Property

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

