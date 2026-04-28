---
kind: property
id: P:Autodesk.Revit.DB.ShapeBuilder.IsValidObject
source: html/6a5c7474-6ea6-4886-d356-204405406596.htm
---
# Autodesk.Revit.DB.ShapeBuilder.IsValidObject Property

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

