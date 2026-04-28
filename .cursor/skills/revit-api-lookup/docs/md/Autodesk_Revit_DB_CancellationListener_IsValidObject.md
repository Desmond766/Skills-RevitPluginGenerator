---
kind: property
id: P:Autodesk.Revit.DB.CancellationListener.IsValidObject
source: html/b7c50f0e-b261-8fe0-1638-c7233c8ae837.htm
---
# Autodesk.Revit.DB.CancellationListener.IsValidObject Property

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

