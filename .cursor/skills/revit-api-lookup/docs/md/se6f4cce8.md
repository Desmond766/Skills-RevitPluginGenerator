---
kind: property
id: P:Autodesk.Revit.DB.IFC.IFCFileReadOptions.IsValidObject
source: html/1ee96b3e-a8e7-4d35-f19d-47e0dd773a10.htm
---
# Autodesk.Revit.DB.IFC.IFCFileReadOptions.IsValidObject Property

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

