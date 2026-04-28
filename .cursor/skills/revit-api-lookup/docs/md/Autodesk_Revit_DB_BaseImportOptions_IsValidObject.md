---
kind: property
id: P:Autodesk.Revit.DB.BaseImportOptions.IsValidObject
source: html/505ddddc-c6ee-8c1f-35b5-021ddb91a7ce.htm
---
# Autodesk.Revit.DB.BaseImportOptions.IsValidObject Property

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

