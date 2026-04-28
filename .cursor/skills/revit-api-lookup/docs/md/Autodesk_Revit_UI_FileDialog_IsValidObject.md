---
kind: property
id: P:Autodesk.Revit.UI.FileDialog.IsValidObject
source: html/07a3a2f0-4790-3931-544c-26d69ddb2bed.htm
---
# Autodesk.Revit.UI.FileDialog.IsValidObject Property

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

