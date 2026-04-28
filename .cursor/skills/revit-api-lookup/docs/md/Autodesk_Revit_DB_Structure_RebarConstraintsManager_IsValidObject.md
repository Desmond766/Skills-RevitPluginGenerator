---
kind: property
id: P:Autodesk.Revit.DB.Structure.RebarConstraintsManager.IsValidObject
source: html/8a9d9f87-6f3f-40c9-578b-a2a5b6cb7311.htm
---
# Autodesk.Revit.DB.Structure.RebarConstraintsManager.IsValidObject Property

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

