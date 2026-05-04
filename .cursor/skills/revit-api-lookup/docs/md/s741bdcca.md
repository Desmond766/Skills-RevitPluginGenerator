---
kind: property
id: P:Autodesk.Revit.DB.SchedulableField.IsValidObject
source: html/d0c82127-a76e-6c8b-9d5c-8df1e52dae0c.htm
---
# Autodesk.Revit.DB.SchedulableField.IsValidObject Property

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

