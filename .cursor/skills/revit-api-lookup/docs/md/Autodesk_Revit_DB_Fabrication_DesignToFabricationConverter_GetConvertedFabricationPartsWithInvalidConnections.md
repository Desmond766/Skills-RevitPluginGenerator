---
kind: method
id: M:Autodesk.Revit.DB.Fabrication.DesignToFabricationConverter.GetConvertedFabricationPartsWithInvalidConnections
source: html/2a2a5846-56b2-6d88-6807-d89ddae56f3a.htm
---
# Autodesk.Revit.DB.Fabrication.DesignToFabricationConverter.GetConvertedFabricationPartsWithInvalidConnections Method

Gets the collection of converted fabrication parts with invalid connections.

## Syntax (C#)
```csharp
public IDictionary<ElementId, ElementId> GetConvertedFabricationPartsWithInvalidConnections()
```

## Remarks
This set of element identifiers is only available after the Convert method has been invoked, and returns DesignToFabricationConverterResult::Enum::PartialFailure.

