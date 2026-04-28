---
kind: method
id: M:Autodesk.Revit.DB.Analysis.AnalysisDisplayStyle.CreateAnalysisDisplayStyle(Autodesk.Revit.DB.Document,System.String,Autodesk.Revit.DB.Analysis.AnalysisDisplayDiagramSettings,Autodesk.Revit.DB.Analysis.AnalysisDisplayColorSettings,Autodesk.Revit.DB.Analysis.AnalysisDisplayLegendSettings)
source: html/dae780a2-bbbc-500f-6da0-4f8f4863d67c.htm
---
# Autodesk.Revit.DB.Analysis.AnalysisDisplayStyle.CreateAnalysisDisplayStyle Method

Factory method - creates analysis display style object of type Diagram for the given document.

## Syntax (C#)
```csharp
public static AnalysisDisplayStyle CreateAnalysisDisplayStyle(
	Document document,
	string name,
	AnalysisDisplayDiagramSettings diagramSettings,
	AnalysisDisplayColorSettings colorSettings,
	AnalysisDisplayLegendSettings legendSettings
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - Document for which analysis display style object is created.
- **name** (`System.String`) - Name of the analysis display style within the %document%.
- **diagramSettings** (`Autodesk.Revit.DB.Analysis.AnalysisDisplayDiagramSettings`) - Diagram settings for the style.
- **colorSettings** (`Autodesk.Revit.DB.Analysis.AnalysisDisplayColorSettings`) - Color settings for the style.
- **legendSettings** (`Autodesk.Revit.DB.Analysis.AnalysisDisplayLegendSettings`) - Legend settings for the style.

## Returns
New analysis display style object.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentsInconsistentException** - document is a family.
 -or-
 name is not unique in document.

