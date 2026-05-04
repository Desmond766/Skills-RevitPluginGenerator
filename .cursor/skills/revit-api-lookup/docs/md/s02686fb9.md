---
kind: property
id: P:Autodesk.Revit.DB.IFC.IFCData.IsValidObject
source: html/db28c8bc-f15c-2719-c06a-b18d954cdc1c.htm
---
# Autodesk.Revit.DB.IFC.IFCData.IsValidObject Property

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

