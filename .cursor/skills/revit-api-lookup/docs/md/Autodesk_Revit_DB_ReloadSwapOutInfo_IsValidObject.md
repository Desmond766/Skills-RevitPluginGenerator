---
kind: property
id: P:Autodesk.Revit.DB.ReloadSwapOutInfo.IsValidObject
source: html/e5a773f7-5d69-2f89-7795-45ca4516f2f4.htm
---
# Autodesk.Revit.DB.ReloadSwapOutInfo.IsValidObject Property

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

