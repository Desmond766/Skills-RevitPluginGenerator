---
kind: property
id: P:Autodesk.Revit.DB.ColorFillSchemeEntry.IsValidObject
source: html/e81120c3-6cb6-a8c4-0fed-693c7642f2cf.htm
---
# Autodesk.Revit.DB.ColorFillSchemeEntry.IsValidObject Property

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

