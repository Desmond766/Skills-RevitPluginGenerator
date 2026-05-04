---
kind: property
id: P:Autodesk.Revit.DB.WorksharingSaveAsOptions.IsValidObject
source: html/984194d4-ac5b-2b32-9c27-5b31c8956b7e.htm
---
# Autodesk.Revit.DB.WorksharingSaveAsOptions.IsValidObject Property

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

