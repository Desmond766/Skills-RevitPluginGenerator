---
kind: method
id: M:Autodesk.Revit.DB.Analysis.SpatialFieldManager.RegisterResult(Autodesk.Revit.DB.Analysis.AnalysisResultSchema)
source: html/6531b93d-4f67-2663-2a24-ac3d669fdd04.htm
---
# Autodesk.Revit.DB.Analysis.SpatialFieldManager.RegisterResult Method

Registers result and assigns it a unique result index

## Syntax (C#)
```csharp
public int RegisterResult(
	AnalysisResultSchema resultSchema
)
```

## Parameters
- **resultSchema** (`Autodesk.Revit.DB.Analysis.AnalysisResultSchema`) - Result schema to be registered

## Returns
Unique index assigned to the result

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - name of resultSchema is not unique in view
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

