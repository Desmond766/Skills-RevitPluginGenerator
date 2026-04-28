---
kind: property
id: P:Autodesk.Revit.DB.IFC.HostObjectSubcomponentInfo.IsValidObject
source: html/53f10a7c-8491-ce4f-0139-ceb2e99fdf8b.htm
---
# Autodesk.Revit.DB.IFC.HostObjectSubcomponentInfo.IsValidObject Property

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

