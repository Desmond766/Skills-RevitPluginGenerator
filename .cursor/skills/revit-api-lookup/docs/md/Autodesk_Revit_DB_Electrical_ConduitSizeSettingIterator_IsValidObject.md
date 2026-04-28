---
kind: property
id: P:Autodesk.Revit.DB.Electrical.ConduitSizeSettingIterator.IsValidObject
source: html/bb5514c9-9f19-76f0-fe77-55d656fc3197.htm
---
# Autodesk.Revit.DB.Electrical.ConduitSizeSettingIterator.IsValidObject Property

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

