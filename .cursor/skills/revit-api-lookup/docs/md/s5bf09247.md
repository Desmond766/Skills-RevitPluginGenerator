---
kind: property
id: P:Autodesk.Revit.DB.IFC.IFCGuidKey.IsValidObject
source: html/714a3671-c3db-3e1b-5540-030514244f6a.htm
---
# Autodesk.Revit.DB.IFC.IFCGuidKey.IsValidObject Property

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

