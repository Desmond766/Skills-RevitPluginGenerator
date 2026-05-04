---
kind: property
id: P:Autodesk.Revit.DB.GBXMLExportOptions.IsValidObject
source: html/83376d0b-7256-203e-c9b4-eb04c6c3a522.htm
---
# Autodesk.Revit.DB.GBXMLExportOptions.IsValidObject Property

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

