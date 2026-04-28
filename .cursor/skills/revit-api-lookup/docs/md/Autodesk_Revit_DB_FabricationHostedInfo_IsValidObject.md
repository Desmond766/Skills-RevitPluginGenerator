---
kind: property
id: P:Autodesk.Revit.DB.FabricationHostedInfo.IsValidObject
source: html/beb0c33a-7991-8b05-e264-05d4ae17fc99.htm
---
# Autodesk.Revit.DB.FabricationHostedInfo.IsValidObject Property

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

