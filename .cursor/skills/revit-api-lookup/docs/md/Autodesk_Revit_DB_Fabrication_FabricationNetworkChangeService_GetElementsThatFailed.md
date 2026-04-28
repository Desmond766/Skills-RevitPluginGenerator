---
kind: method
id: M:Autodesk.Revit.DB.Fabrication.FabricationNetworkChangeService.GetElementsThatFailed
source: html/7bc30db4-1cae-1acb-c346-d164d5b90822.htm
---
# Autodesk.Revit.DB.Fabrication.FabricationNetworkChangeService.GetElementsThatFailed Method

Gets the set of fabrication parts that had failures due to either there was no corresponding part in the service, the size was out of range, or a connection could not be made.

## Syntax (C#)
```csharp
public ISet<ElementId> GetElementsThatFailed()
```

## Remarks
This set of element identifiers is only available after the ChangeService or ChangeSize method has been invoked, and returns FabricationNetworkChangeServiceResult::Enum::PartialFailure.

