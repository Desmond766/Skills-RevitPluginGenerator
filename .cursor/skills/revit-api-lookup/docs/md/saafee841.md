---
kind: property
id: P:Autodesk.Revit.DB.Lighting.InitialColor.IsValidObject
source: html/f05595fe-b0e4-2d90-2cd0-34de296e6d16.htm
---
# Autodesk.Revit.DB.Lighting.InitialColor.IsValidObject Property

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

