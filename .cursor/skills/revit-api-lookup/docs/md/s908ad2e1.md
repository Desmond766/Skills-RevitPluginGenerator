---
kind: property
id: P:Autodesk.Revit.UI.UIView.IsValidObject
source: html/8099518f-79a5-1c66-c7ea-2ee0394ac77a.htm
---
# Autodesk.Revit.UI.UIView.IsValidObject Property

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

