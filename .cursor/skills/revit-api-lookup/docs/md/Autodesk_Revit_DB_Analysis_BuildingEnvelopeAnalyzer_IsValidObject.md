---
kind: property
id: P:Autodesk.Revit.DB.Analysis.BuildingEnvelopeAnalyzer.IsValidObject
source: html/dc6fdfc6-aaa9-cccd-612b-7123354af9a6.htm
---
# Autodesk.Revit.DB.Analysis.BuildingEnvelopeAnalyzer.IsValidObject Property

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

