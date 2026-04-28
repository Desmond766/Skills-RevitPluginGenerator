---
kind: property
id: P:Autodesk.Revit.UI.RibbonButtonOptions.IsValidObject
source: html/582d6285-f7e5-2c04-8177-135174e09c0d.htm
---
# Autodesk.Revit.UI.RibbonButtonOptions.IsValidObject Property

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

