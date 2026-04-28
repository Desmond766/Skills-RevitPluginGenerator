---
kind: property
id: P:Autodesk.Revit.DB.ExternalResourceMatchOptions.IsValidObject
source: html/ace8e6ef-96b7-1124-ab68-5e03e27331c8.htm
---
# Autodesk.Revit.DB.ExternalResourceMatchOptions.IsValidObject Property

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

