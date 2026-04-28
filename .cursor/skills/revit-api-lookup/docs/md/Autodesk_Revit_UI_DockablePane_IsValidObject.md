---
kind: property
id: P:Autodesk.Revit.UI.DockablePane.IsValidObject
source: html/8e530ce4-2422-84da-4519-46312a8143b7.htm
---
# Autodesk.Revit.UI.DockablePane.IsValidObject Property

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

