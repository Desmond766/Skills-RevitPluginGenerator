---
kind: method
id: M:Autodesk.Revit.DB.Analysis.BuildingEnvelopeAnalyzer.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.Analysis.BuildingEnvelopeAnalyzerOptions)
zh: 创建、新建、生成、建立、新增
source: html/478ff179-a9e1-2d62-e4ae-d462f0d24446.htm
---
# Autodesk.Revit.DB.Analysis.BuildingEnvelopeAnalyzer.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new analyzer.

## Syntax (C#)
```csharp
public static BuildingEnvelopeAnalyzer Create(
	Document document,
	BuildingEnvelopeAnalyzerOptions options
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document that contains the physical model of the building.
- **options** (`Autodesk.Revit.DB.Analysis.BuildingEnvelopeAnalyzerOptions`) - Options for the method analyzing the building elements for the building envelope.

## Returns
The created analyzer.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

