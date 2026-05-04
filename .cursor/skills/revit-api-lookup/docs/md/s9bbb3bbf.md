---
kind: property
id: P:Autodesk.Revit.DB.Mechanical.DuctPressureDropData.IsValidObject
source: html/8f1feb00-c38f-1462-fb57-5c8c345e9d38.htm
---
# Autodesk.Revit.DB.Mechanical.DuctPressureDropData.IsValidObject Property

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

