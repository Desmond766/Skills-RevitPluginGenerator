---
kind: method
id: M:Autodesk.Revit.DB.Electrical.CircuitNamingScheme.IsValidCombinedParameters(Autodesk.Revit.DB.Document,System.Collections.Generic.IList{Autodesk.Revit.DB.TableCellCombinedParameterData})
source: html/67351dc2-02d0-4c5a-d72b-23fc3a4c0caf.htm
---
# Autodesk.Revit.DB.Electrical.CircuitNamingScheme.IsValidCombinedParameters Method

Validates whether the combined parameters is valid.

## Syntax (C#)
```csharp
public static bool IsValidCombinedParameters(
	Document aDocument,
	IList<TableCellCombinedParameterData> data
)
```

## Parameters
- **aDocument** (`Autodesk.Revit.DB.Document`) - The document.
- **data** (`System.Collections.Generic.IList < TableCellCombinedParameterData >`) - The array of TableCellCombinedParameterData to be set as combined parameters.

## Returns
Returns true if the combined parameters are valid, and false otherwise.

## Remarks
Currently the following parameters are supported: Shared Parameters RBS_ELEC_CIRCUIT_NAME RBS_ELEC_CIRCUIT_PANEL_PARAM RBS_ELEC_CIRCUIT_TYPE CIRCUIT_LOAD_CLASSIFICATION_ABBREVIATION_PARAM RBS_ELEC_CIRCUIT_NAMING_INDEX RBS_ELEC_NUMBER_OF_POLES RBS_ELEC_CIRCUIT_RATING_PARAM RBS_ELEC_CIRCUIT_FRAME_PARAM RBS_ELEC_VOLTAGE CIRCUIT_PHASE_PARAM CIRCUIT_WAYS_PARAM RBS_ELEC_CIRCUIT_SLOT_INDEX

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

