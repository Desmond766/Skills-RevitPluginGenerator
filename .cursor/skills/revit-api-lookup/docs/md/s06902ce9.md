---
kind: method
id: M:Autodesk.Revit.DB.Structure.FabricSheet.GetSegmentParameterIdsAndLengths(System.Boolean)
source: html/1542c812-735a-0483-e5b5-7f02bc16b2f9.htm
---
# Autodesk.Revit.DB.Structure.FabricSheet.GetSegmentParameterIdsAndLengths Method

Returns the array of pairs [parameter ID, length] that correspond to segments of a bent fabric sheet (like A, B, C, D etc.).

## Syntax (C#)
```csharp
public IDictionary<ElementId, double> GetSegmentParameterIdsAndLengths(
	bool rounded
)
```

## Parameters
- **rounded** (`System.Boolean`) - Set to true to return rounded values for segments lengths.

## Returns
Array of pairs [parameter ID, length] that correspond to segments of a bent fabric sheet (like A, B, C, D etc.) is returned for bend fabric sheet.
 For flat fabric sheet (not bent) empty array is returned.

## Remarks
This method does not provide alphabetical nor any other order of returned parameters.

