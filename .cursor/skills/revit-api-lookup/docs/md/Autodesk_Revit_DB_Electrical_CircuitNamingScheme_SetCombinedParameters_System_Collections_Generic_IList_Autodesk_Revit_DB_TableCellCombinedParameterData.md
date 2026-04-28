---
kind: method
id: M:Autodesk.Revit.DB.Electrical.CircuitNamingScheme.SetCombinedParameters(System.Collections.Generic.IList{Autodesk.Revit.DB.TableCellCombinedParameterData})
source: html/edd9f04a-2a63-3426-b9d8-4b72a0c74791.htm
---
# Autodesk.Revit.DB.Electrical.CircuitNamingScheme.SetCombinedParameters Method

Sets combined parameters array.

## Syntax (C#)
```csharp
public void SetCombinedParameters(
	IList<TableCellCombinedParameterData> data
)
```

## Parameters
- **data** (`System.Collections.Generic.IList < TableCellCombinedParameterData >`) - The array of TableCellCombinedParameterData to be set as combined parameters.

## Remarks
Currently the following parameters are supported: Project Parameters Shared Parameters RBS_ELEC_CIRCUIT_NAME RBS_ELEC_CIRCUIT_PANEL_PARAM RBS_ELEC_CIRCUIT_TYPE CIRCUIT_LOAD_CLASSIFICATION_ABBREVIATION_PARAM RBS_ELEC_CIRCUIT_NAMING_INDEX RBS_ELEC_NUMBER_OF_POLES RBS_ELEC_CIRCUIT_RATING_PARAM RBS_ELEC_CIRCUIT_FRAME_PARAM RBS_ELEC_VOLTAGE CIRCUIT_PHASE_PARAM CIRCUIT_WAYS_PARAM RBS_ELEC_CIRCUIT_SLOT_INDEX

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The data contains invalid parameter id.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

