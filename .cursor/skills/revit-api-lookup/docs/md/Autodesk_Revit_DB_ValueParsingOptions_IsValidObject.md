---
kind: property
id: P:Autodesk.Revit.DB.ValueParsingOptions.IsValidObject
source: html/56961669-45d7-f336-8fd6-c96ba7860f00.htm
---
# Autodesk.Revit.DB.ValueParsingOptions.IsValidObject Property

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

