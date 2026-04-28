---
kind: property
id: P:Autodesk.Revit.DB.SolidOptions.IsValidObject
source: html/e66a8d28-7730-8de4-0728-f584c2ccf230.htm
---
# Autodesk.Revit.DB.SolidOptions.IsValidObject Property

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

