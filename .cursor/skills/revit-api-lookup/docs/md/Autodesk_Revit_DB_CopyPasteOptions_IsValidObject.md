---
kind: property
id: P:Autodesk.Revit.DB.CopyPasteOptions.IsValidObject
source: html/3df0b78d-5bd4-c944-a350-e4f0423bdf15.htm
---
# Autodesk.Revit.DB.CopyPasteOptions.IsValidObject Property

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

