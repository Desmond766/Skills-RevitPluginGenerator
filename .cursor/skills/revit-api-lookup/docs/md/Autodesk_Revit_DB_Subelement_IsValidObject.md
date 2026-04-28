---
kind: property
id: P:Autodesk.Revit.DB.Subelement.IsValidObject
source: html/d1cfc136-56e5-614b-8d23-6b5ef2c7c874.htm
---
# Autodesk.Revit.DB.Subelement.IsValidObject Property

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

