---
kind: property
id: P:Autodesk.Revit.DB.Mechanical.DuctFittingAndAccessoryPressureDropData.IsValidObject
source: html/8ce801ff-820f-6245-8548-5c7c3e53aa00.htm
---
# Autodesk.Revit.DB.Mechanical.DuctFittingAndAccessoryPressureDropData.IsValidObject Property

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

