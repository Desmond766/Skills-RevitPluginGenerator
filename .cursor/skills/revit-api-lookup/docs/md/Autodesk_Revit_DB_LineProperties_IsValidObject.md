---
kind: property
id: P:Autodesk.Revit.DB.LineProperties.IsValidObject
source: html/fff7440d-6c63-f9cd-20a3-389eef8e1680.htm
---
# Autodesk.Revit.DB.LineProperties.IsValidObject Property

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

