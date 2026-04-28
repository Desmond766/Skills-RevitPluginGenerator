---
kind: property
id: P:Autodesk.Revit.DB.IFC.ImporterIFC.IsValidObject
source: html/3520bb7b-fd72-99d9-358a-79fd63ab80e9.htm
---
# Autodesk.Revit.DB.IFC.ImporterIFC.IsValidObject Property

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

