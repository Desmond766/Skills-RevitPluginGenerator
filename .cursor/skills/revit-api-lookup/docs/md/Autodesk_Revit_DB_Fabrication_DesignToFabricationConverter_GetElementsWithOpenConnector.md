---
kind: method
id: M:Autodesk.Revit.DB.Fabrication.DesignToFabricationConverter.GetElementsWithOpenConnector
source: html/1b8323a9-dd24-c818-e74c-e29b346000d3.htm
---
# Autodesk.Revit.DB.Fabrication.DesignToFabricationConverter.GetElementsWithOpenConnector Method

Gets the set of fabrication part or MEP design element identifiers with open connectors, caused by fittings failing to convert.

## Syntax (C#)
```csharp
public ISet<ElementId> GetElementsWithOpenConnector()
```

## Remarks
This set of element identifiers is only available after the Convert method has been invoked, and returns DesignToFabricationConverterResult::Enum::PartialFailure.

