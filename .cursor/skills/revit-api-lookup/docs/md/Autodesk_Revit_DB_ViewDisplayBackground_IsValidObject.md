---
kind: property
id: P:Autodesk.Revit.DB.ViewDisplayBackground.IsValidObject
source: html/4a403d36-b5bd-41ea-3505-7eafb9a89544.htm
---
# Autodesk.Revit.DB.ViewDisplayBackground.IsValidObject Property

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

