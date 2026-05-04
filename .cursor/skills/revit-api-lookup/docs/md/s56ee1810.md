---
kind: method
id: M:Autodesk.Revit.DB.MEPModel.GetElectricalSystems
source: html/ef8e7119-9fa4-3024-d43d-591759b6098b.htm
---
# Autodesk.Revit.DB.MEPModel.GetElectricalSystems Method

Retrieves the electrical systems that are currently created using this MEPModel.

## Syntax (C#)
```csharp
public ISet<ElectricalSystem> GetElectricalSystems()
```

## Remarks
This property returns a set of Electrical Systems. If there are no electrical systems created
 for this model, this property will be an empty set.
 This method supersedes an older ElectricalSystems property which has been deprecated.

