---
kind: property
id: P:Autodesk.Revit.DB.Analysis.AnalysisDisplayVectorSettings.IsValidObject
source: html/c29a3751-97ea-75cb-2982-f2be38b8e7f5.htm
---
# Autodesk.Revit.DB.Analysis.AnalysisDisplayVectorSettings.IsValidObject Property

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

