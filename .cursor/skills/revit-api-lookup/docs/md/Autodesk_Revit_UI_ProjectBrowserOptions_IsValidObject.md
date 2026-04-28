---
kind: property
id: P:Autodesk.Revit.UI.ProjectBrowserOptions.IsValidObject
source: html/2a718583-4f53-bc57-8dd1-c9f06e38f4d1.htm
---
# Autodesk.Revit.UI.ProjectBrowserOptions.IsValidObject Property

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

