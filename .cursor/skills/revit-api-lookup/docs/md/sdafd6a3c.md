---
kind: property
id: P:Autodesk.Revit.DB.ExternalResourceBrowserData.IsValidObject
source: html/4b2f627f-7394-baf8-cf33-facd7e6fbe8b.htm
---
# Autodesk.Revit.DB.ExternalResourceBrowserData.IsValidObject Property

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

