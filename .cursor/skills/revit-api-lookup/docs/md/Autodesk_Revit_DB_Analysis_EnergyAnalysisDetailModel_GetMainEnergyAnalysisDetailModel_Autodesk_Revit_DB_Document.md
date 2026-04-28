---
kind: method
id: M:Autodesk.Revit.DB.Analysis.EnergyAnalysisDetailModel.GetMainEnergyAnalysisDetailModel(Autodesk.Revit.DB.Document)
source: html/622db406-ad7e-2a3a-7f3e-e80e803bb353.htm
---
# Autodesk.Revit.DB.Analysis.EnergyAnalysisDetailModel.GetMainEnergyAnalysisDetailModel Method

Gets the EnergyAnalysisDetailModel in given document.

## Syntax (C#)
```csharp
public static EnergyAnalysisDetailModel GetMainEnergyAnalysisDetailModel(
	Document document
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document that contains the physical model of the building.

## Returns
Returns the EnergyAnalysisDetailModel contained in the document, if it exists. If it does not exist, this returns Nothing nullptr a null reference ( Nothing in Visual Basic) .

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

