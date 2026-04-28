---
kind: property
id: P:Autodesk.Revit.DB.Structure.StructuralSections.StructuralSectionAnalysisParams.IsValidObject
source: html/c1b44e5d-5fa7-fcfe-c356-d9cf1594c4d9.htm
---
# Autodesk.Revit.DB.Structure.StructuralSections.StructuralSectionAnalysisParams.IsValidObject Property

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

