---
kind: property
id: P:Autodesk.Revit.DB.ExportLinetypeKey.IsValidObject
source: html/bf830c0f-37f1-76b8-b9c7-1937cd2cc337.htm
---
# Autodesk.Revit.DB.ExportLinetypeKey.IsValidObject Property

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

