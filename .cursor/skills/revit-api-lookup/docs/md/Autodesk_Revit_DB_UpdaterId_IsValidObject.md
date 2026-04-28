---
kind: property
id: P:Autodesk.Revit.DB.UpdaterId.IsValidObject
source: html/eddcfdd6-9932-8a92-ea03-879d9d8d5fec.htm
---
# Autodesk.Revit.DB.UpdaterId.IsValidObject Property

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

