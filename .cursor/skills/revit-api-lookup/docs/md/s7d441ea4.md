---
kind: type
id: T:Autodesk.Revit.DB.Analysis.AnalysisResultSchema
source: html/90969170-ac45-68e6-2527-f6fba5b3f7ae.htm
---
# Autodesk.Revit.DB.Analysis.AnalysisResultSchema

Contains all information about one analysis result. Each result may contain several measurements.

## Syntax (C#)
```csharp
public class AnalysisResultSchema : IDisposable
```

## Remarks
In order to take effect, the AnalysisResultSchema object has to be registered by calling SpatialFieldManager::RegisterResult, which returns result index for future references;
 to make changes to the properties of an already registered object, use method SpatialFieldManager::SetResultSchema and supply result index and replacing object.

