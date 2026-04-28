---
kind: property
id: P:Autodesk.Revit.DB.OverrideGraphicSettings.IsValidObject
source: html/0c5eb670-de18-2456-6b22-f062212484b3.htm
---
# Autodesk.Revit.DB.OverrideGraphicSettings.IsValidObject Property

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

