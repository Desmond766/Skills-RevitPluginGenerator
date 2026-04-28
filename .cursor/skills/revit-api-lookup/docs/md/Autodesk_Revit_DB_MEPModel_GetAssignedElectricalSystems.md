---
kind: method
id: M:Autodesk.Revit.DB.MEPModel.GetAssignedElectricalSystems
source: html/dbdec982-fe0c-ada0-bf5c-cc9d7967f6f0.htm
---
# Autodesk.Revit.DB.MEPModel.GetAssignedElectricalSystems Method

Retrieves the electrical systems this electrical panel currently is assigned to.

## Syntax (C#)
```csharp
public ISet<ElectricalSystem> GetAssignedElectricalSystems()
```

## Remarks
This property returns a set of Electrical Systems. If there are no electrical systems created
 for this model, this property will be an empty set.
 This method supersedes an older AssignedElectricalSystems property which has been deprecated.

