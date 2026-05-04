---
kind: property
id: P:Autodesk.Revit.DB.FabricationItemFile.IsValidObject
source: html/fd1bb4d1-9f6f-c330-b156-be71a86ec518.htm
---
# Autodesk.Revit.DB.FabricationItemFile.IsValidObject Property

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

