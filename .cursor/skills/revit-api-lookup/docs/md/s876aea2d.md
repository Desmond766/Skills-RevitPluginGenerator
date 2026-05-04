---
kind: property
id: P:Autodesk.Revit.DB.GlobalParametersManager.IsValidObject
source: html/b6edb30b-f31b-688c-baa2-2c8eb7f2d6cc.htm
---
# Autodesk.Revit.DB.GlobalParametersManager.IsValidObject Property

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

