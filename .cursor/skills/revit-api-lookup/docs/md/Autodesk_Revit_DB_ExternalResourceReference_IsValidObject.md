---
kind: property
id: P:Autodesk.Revit.DB.ExternalResourceReference.IsValidObject
source: html/19caed9b-7603-1775-a6e4-ab0c148c0f2c.htm
---
# Autodesk.Revit.DB.ExternalResourceReference.IsValidObject Property

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

