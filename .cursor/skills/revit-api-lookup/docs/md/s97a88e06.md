---
kind: property
id: P:Autodesk.Revit.UI.ThinLinesOptions.IsValidObject
source: html/0081a44a-4f6b-317a-9238-0f3c6fbd0fe2.htm
---
# Autodesk.Revit.UI.ThinLinesOptions.IsValidObject Property

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

