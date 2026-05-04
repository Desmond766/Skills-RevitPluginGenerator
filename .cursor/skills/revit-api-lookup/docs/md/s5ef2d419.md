---
kind: method
id: M:Autodesk.Revit.DB.Fabrication.DesignToFabricationConverter.GetDesignElementAndFabricationPartsWithDifferentOffsets
source: html/76cc2368-3903-e988-7323-002985359e5c.htm
---
# Autodesk.Revit.DB.Fabrication.DesignToFabricationConverter.GetDesignElementAndFabricationPartsWithDifferentOffsets Method

Gets the collection of design elements that failed to convert and the associated set of fabrication parts with different offsets.

## Syntax (C#)
```csharp
public IDictionary<ElementId, ISet<ElementId>> GetDesignElementAndFabricationPartsWithDifferentOffsets()
```

## Returns
A map of design element identifiers that were not converted and the associated set fabrication parts left with different offsets.

## Remarks
This set of element identifiers is only available after the Convert method has been invoked, and returns DesignToFabricationConverterResult::Enum::PartialFailure.

