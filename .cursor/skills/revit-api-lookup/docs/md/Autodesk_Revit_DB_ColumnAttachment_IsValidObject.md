---
kind: property
id: P:Autodesk.Revit.DB.ColumnAttachment.IsValidObject
source: html/33fe61b7-b243-6b8b-50f8-24d808d4c5d2.htm
---
# Autodesk.Revit.DB.ColumnAttachment.IsValidObject Property

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

