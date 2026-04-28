---
kind: property
id: P:Autodesk.Revit.UI.DockablePaneState.IsValidObject
source: html/9a1720f3-3bd2-61ae-37d6-0b1ca8104d30.htm
---
# Autodesk.Revit.UI.DockablePaneState.IsValidObject Property

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

