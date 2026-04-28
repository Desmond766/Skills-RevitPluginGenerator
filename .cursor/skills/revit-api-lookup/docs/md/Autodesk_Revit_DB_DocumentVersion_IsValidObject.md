---
kind: property
id: P:Autodesk.Revit.DB.DocumentVersion.IsValidObject
source: html/37073a30-9b18-1ac8-5c12-5d3a60b86b71.htm
---
# Autodesk.Revit.DB.DocumentVersion.IsValidObject Property

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

