---
kind: property
id: P:Autodesk.Revit.DB.Mechanical.DuctSizeSettingIterator.IsValidObject
source: html/a61e3c86-fbc5-dcd5-f79b-19fd5d6edf7a.htm
---
# Autodesk.Revit.DB.Mechanical.DuctSizeSettingIterator.IsValidObject Property

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

