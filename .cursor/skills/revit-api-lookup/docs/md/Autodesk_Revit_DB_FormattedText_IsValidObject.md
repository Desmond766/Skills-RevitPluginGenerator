---
kind: property
id: P:Autodesk.Revit.DB.FormattedText.IsValidObject
source: html/35187b1c-c476-7fe5-e0f9-8ddd963face2.htm
---
# Autodesk.Revit.DB.FormattedText.IsValidObject Property

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

