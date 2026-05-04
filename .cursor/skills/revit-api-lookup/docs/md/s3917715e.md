---
kind: property
id: P:Autodesk.Revit.DB.Analysis.AnalysisDisplayMarkersAndTextSettings.IsValidObject
source: html/60b9e8b8-6954-2f1a-99f8-59f872a47c4e.htm
---
# Autodesk.Revit.DB.Analysis.AnalysisDisplayMarkersAndTextSettings.IsValidObject Property

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

