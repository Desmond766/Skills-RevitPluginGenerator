---
kind: property
id: P:Autodesk.Revit.DB.FamilySizeTableManager.IsValidObject
source: html/24486f6f-3e09-2cf5-3521-c4b6e22a4bea.htm
---
# Autodesk.Revit.DB.FamilySizeTableManager.IsValidObject Property

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

