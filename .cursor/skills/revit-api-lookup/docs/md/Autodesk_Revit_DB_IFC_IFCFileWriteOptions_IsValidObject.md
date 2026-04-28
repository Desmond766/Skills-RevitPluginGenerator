---
kind: property
id: P:Autodesk.Revit.DB.IFC.IFCFileWriteOptions.IsValidObject
source: html/2a214a3d-bd3a-2ff0-8994-4a7ee6837637.htm
---
# Autodesk.Revit.DB.IFC.IFCFileWriteOptions.IsValidObject Property

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

