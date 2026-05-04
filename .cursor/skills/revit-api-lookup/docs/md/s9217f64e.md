---
kind: property
id: P:Autodesk.Revit.DB.TextNoteOptions.IsValidObject
source: html/0a5e9adf-e909-91c7-b307-9e4418e8732b.htm
---
# Autodesk.Revit.DB.TextNoteOptions.IsValidObject Property

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

