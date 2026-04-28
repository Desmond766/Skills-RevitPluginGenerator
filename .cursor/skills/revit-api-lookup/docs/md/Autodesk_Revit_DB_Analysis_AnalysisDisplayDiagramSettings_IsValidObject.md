---
kind: property
id: P:Autodesk.Revit.DB.Analysis.AnalysisDisplayDiagramSettings.IsValidObject
source: html/3c856db3-000f-0701-2c98-0166f725c53f.htm
---
# Autodesk.Revit.DB.Analysis.AnalysisDisplayDiagramSettings.IsValidObject Property

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

