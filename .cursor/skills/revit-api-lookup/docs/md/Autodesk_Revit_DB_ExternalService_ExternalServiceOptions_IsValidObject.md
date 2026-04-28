---
kind: property
id: P:Autodesk.Revit.DB.ExternalService.ExternalServiceOptions.IsValidObject
source: html/1528ea6a-10de-a157-23a8-10b6d3332832.htm
---
# Autodesk.Revit.DB.ExternalService.ExternalServiceOptions.IsValidObject Property

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

