---
kind: property
id: P:Autodesk.Revit.DB.NurbsSurfaceData.IsValidObject
source: html/b9517067-344b-5d1b-8c5d-664b7e7115e1.htm
---
# Autodesk.Revit.DB.NurbsSurfaceData.IsValidObject Property

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

