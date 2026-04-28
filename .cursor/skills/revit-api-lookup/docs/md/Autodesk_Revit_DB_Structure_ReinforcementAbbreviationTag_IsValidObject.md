---
kind: property
id: P:Autodesk.Revit.DB.Structure.ReinforcementAbbreviationTag.IsValidObject
source: html/0a4ac474-2d59-3ab3-0ebd-7f04a8c20b72.htm
---
# Autodesk.Revit.DB.Structure.ReinforcementAbbreviationTag.IsValidObject Property

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

