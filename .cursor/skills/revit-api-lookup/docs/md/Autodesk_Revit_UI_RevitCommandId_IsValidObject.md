---
kind: property
id: P:Autodesk.Revit.UI.RevitCommandId.IsValidObject
source: html/009ccb11-3161-a878-98d8-dcb8a8ac87ff.htm
---
# Autodesk.Revit.UI.RevitCommandId.IsValidObject Property

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

