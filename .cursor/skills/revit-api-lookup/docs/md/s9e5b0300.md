---
kind: method
id: M:Autodesk.Revit.DB.Fabrication.DesignToFabricationConverter.GetDesignElementAndFabricationPartsWithOpenConnectors
source: html/c4cdbf1b-51ea-281a-bd2e-b9ff32695661.htm
---
# Autodesk.Revit.DB.Fabrication.DesignToFabricationConverter.GetDesignElementAndFabricationPartsWithOpenConnectors Method

Gets the collection of design elements that failed to convert and the associated set of fabrication parts with open connectors.

## Syntax (C#)
```csharp
public IDictionary<ElementId, ISet<ElementId>> GetDesignElementAndFabricationPartsWithOpenConnectors()
```

## Returns
A map of design element identifiers that were not converted and the associated set fabrication parts left with open connectors.

## Remarks
This set of element identifiers is only available after the Convert method has been invoked, and returns DesignToFabricationConverterResult::Enum::PartialFailure.

