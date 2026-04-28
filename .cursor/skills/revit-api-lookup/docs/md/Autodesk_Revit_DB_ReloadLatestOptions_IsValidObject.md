---
kind: property
id: P:Autodesk.Revit.DB.ReloadLatestOptions.IsValidObject
source: html/e2e3028e-cc42-6b83-06b1-1cb76fb1fac8.htm
---
# Autodesk.Revit.DB.ReloadLatestOptions.IsValidObject Property

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

