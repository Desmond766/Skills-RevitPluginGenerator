---
kind: property
id: P:Autodesk.Revit.DB.Lighting.InitialIntensity.IsValidObject
source: html/5c5562cc-c39c-e800-b8a1-4861ba2c13b7.htm
---
# Autodesk.Revit.DB.Lighting.InitialIntensity.IsValidObject Property

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

