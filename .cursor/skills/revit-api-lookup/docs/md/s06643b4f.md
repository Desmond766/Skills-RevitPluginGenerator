---
kind: property
id: P:Autodesk.Revit.DB.Architecture.BalusterPlacement.IsValidObject
source: html/a3e1bf6e-0a4f-b972-893a-f09cdfc7c6c1.htm
---
# Autodesk.Revit.DB.Architecture.BalusterPlacement.IsValidObject Property

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

