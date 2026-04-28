---
kind: property
id: P:Autodesk.Revit.DB.Architecture.PostPattern.IsValidObject
source: html/91361ecb-4c2e-1fac-6966-e28db16202d7.htm
---
# Autodesk.Revit.DB.Architecture.PostPattern.IsValidObject Property

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

