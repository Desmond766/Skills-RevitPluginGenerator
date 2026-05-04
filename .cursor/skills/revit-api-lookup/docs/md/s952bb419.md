---
kind: property
id: P:Autodesk.Revit.DB.IFC.IFCRange.IsValidObject
source: html/638a0ef2-7b9a-3bb7-8d65-e7f80f742e5e.htm
---
# Autodesk.Revit.DB.IFC.IFCRange.IsValidObject Property

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

