---
kind: property
id: P:Autodesk.Revit.DB.FailuresAccessor.IsValidObject
source: html/f04d247c-f5a2-0589-8c53-abdd57d2897f.htm
---
# Autodesk.Revit.DB.FailuresAccessor.IsValidObject Property

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

