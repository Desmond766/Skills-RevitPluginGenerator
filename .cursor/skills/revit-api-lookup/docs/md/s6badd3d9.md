---
kind: property
id: P:Autodesk.Revit.UI.FamilyInstancePlacingArgs.IsValidObject
source: html/bb260d9b-eff7-8438-7ce5-42997d3ccef7.htm
---
# Autodesk.Revit.UI.FamilyInstancePlacingArgs.IsValidObject Property

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

