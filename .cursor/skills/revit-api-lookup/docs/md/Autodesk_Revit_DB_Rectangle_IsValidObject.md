---
kind: property
id: P:Autodesk.Revit.DB.Rectangle.IsValidObject
source: html/6848a07e-ec73-eab0-90c1-a01b1a909cd9.htm
---
# Autodesk.Revit.DB.Rectangle.IsValidObject Property

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

