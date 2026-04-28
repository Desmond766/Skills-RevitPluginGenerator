---
kind: property
id: P:Autodesk.Revit.DB.Structure.ReleaseConditions.IsValidObject
source: html/116f0a1c-ef09-46e8-8a87-6455b7f92c7d.htm
---
# Autodesk.Revit.DB.Structure.ReleaseConditions.IsValidObject Property

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

