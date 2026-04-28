---
kind: property
id: P:Autodesk.Revit.DB.Element.IsValidObject
zh: 构件、图元、元素
source: html/0ffcf585-a39d-623c-9b5b-ab63c7bebfb6.htm
---
# Autodesk.Revit.DB.Element.IsValidObject Property

**中文**: 构件、图元、元素

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

