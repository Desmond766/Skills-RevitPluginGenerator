---
kind: property
id: P:Autodesk.Revit.DB.Transform2D.IsValidObject
source: html/1b6161d1-42da-1365-f796-382f297730da.htm
---
# Autodesk.Revit.DB.Transform2D.IsValidObject Property

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

