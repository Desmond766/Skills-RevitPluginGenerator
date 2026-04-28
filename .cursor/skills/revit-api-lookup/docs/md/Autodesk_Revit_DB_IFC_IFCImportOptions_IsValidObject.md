---
kind: property
id: P:Autodesk.Revit.DB.IFC.IFCImportOptions.IsValidObject
source: html/a4e4a737-c53c-62e5-a9c2-c424f1f80951.htm
---
# Autodesk.Revit.DB.IFC.IFCImportOptions.IsValidObject Property

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

