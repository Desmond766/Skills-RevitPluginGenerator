---
kind: property
id: P:Autodesk.Revit.DB.Analysis.SystemsAnalysisOptions.IsValidObject
source: html/8f294477-76f9-6cbd-47d6-6207107b2704.htm
---
# Autodesk.Revit.DB.Analysis.SystemsAnalysisOptions.IsValidObject Property

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

