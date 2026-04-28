---
kind: property
id: P:Autodesk.Revit.DB.ViewDisplayModel.IsValidObject
source: html/15c0ee18-e367-0f56-053f-8bda134c6f0f.htm
---
# Autodesk.Revit.DB.ViewDisplayModel.IsValidObject Property

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

