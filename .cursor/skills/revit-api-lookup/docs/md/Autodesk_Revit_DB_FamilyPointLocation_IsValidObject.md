---
kind: property
id: P:Autodesk.Revit.DB.FamilyPointLocation.IsValidObject
source: html/63589c61-bb00-08d1-d561-c63807eb8b3c.htm
---
# Autodesk.Revit.DB.FamilyPointLocation.IsValidObject Property

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

