---
kind: method
id: M:Autodesk.Revit.DB.Analysis.SpatialFieldManager.SetResultSchema(System.Int32,Autodesk.Revit.DB.Analysis.AnalysisResultSchema)
source: html/312882d1-a3a0-fd15-db97-fbdc6c44b72d.htm
---
# Autodesk.Revit.DB.Analysis.SpatialFieldManager.SetResultSchema Method

Sets a new value for an existing result schema in the result registry

## Syntax (C#)
```csharp
public void SetResultSchema(
	int idx,
	AnalysisResultSchema resultSchema
)
```

## Parameters
- **idx** (`System.Int32`) - Index of registered result schema
- **resultSchema** (`Autodesk.Revit.DB.Analysis.AnalysisResultSchema`) - Result schema replacing the existent one

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - idx refers to non-existent result schema
 -or-
 name of resultSchema is not unique in view
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

