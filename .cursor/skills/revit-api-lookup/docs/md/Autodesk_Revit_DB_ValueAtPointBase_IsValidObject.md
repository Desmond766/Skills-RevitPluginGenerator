---
kind: property
id: P:Autodesk.Revit.DB.ValueAtPointBase.IsValidObject
source: html/586e4bc0-785e-8c96-0801-480dd86f096c.htm
---
# Autodesk.Revit.DB.ValueAtPointBase.IsValidObject Property

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

