---
kind: property
id: P:Autodesk.Revit.DB.ExtensibleStorage.FieldBuilder.IsValidObject
source: html/b749ab6a-805c-598f-680c-7a6befc14512.htm
---
# Autodesk.Revit.DB.ExtensibleStorage.FieldBuilder.IsValidObject Property

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

