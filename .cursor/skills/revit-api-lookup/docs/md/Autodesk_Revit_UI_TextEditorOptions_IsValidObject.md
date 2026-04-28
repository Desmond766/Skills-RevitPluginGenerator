---
kind: property
id: P:Autodesk.Revit.UI.TextEditorOptions.IsValidObject
source: html/a40a0f16-2eeb-3135-12a5-f5c197645b4b.htm
---
# Autodesk.Revit.UI.TextEditorOptions.IsValidObject Property

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

