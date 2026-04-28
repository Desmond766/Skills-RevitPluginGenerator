---
kind: method
id: M:Autodesk.Revit.DB.Analysis.EnergyDataSettings.IsDocumentUsingEnergyDataAnalyticalModel(Autodesk.Revit.DB.Document)
source: html/53794ee4-dc48-fadf-065a-dbf03467dd1b.htm
---
# Autodesk.Revit.DB.Analysis.EnergyDataSettings.IsDocumentUsingEnergyDataAnalyticalModel Method

Get EnergyDataSettings element and if it exists, return result from getCreateAnalyticalModel.

## Syntax (C#)
```csharp
public static bool IsDocumentUsingEnergyDataAnalyticalModel(
	Document ccda
)
```

## Parameters
- **ccda** (`Autodesk.Revit.DB.Document`) - The document.

## Returns
Returns true if the Conceptual Energy Analytical Model is enabled, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

