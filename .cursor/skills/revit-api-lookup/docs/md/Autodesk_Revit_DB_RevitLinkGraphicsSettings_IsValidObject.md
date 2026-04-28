---
kind: property
id: P:Autodesk.Revit.DB.RevitLinkGraphicsSettings.IsValidObject
source: html/69fca39d-fec1-7e96-bb39-ec5d77a4d8f8.htm
---
# Autodesk.Revit.DB.RevitLinkGraphicsSettings.IsValidObject Property

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

