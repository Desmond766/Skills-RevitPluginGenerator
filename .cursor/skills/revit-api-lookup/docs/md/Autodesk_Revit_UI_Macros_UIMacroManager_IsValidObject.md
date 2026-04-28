---
kind: property
id: P:Autodesk.Revit.UI.Macros.UIMacroManager.IsValidObject
source: html/decb5038-65d7-4977-07b1-f8d0718e3305.htm
---
# Autodesk.Revit.UI.Macros.UIMacroManager.IsValidObject Property

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

