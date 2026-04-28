---
kind: property
id: P:Autodesk.Revit.DB.Document.PlanTopology(Autodesk.Revit.DB.Level,Autodesk.Revit.DB.Phase)
zh: 文档、文件
source: html/215a0d2b-0f9f-1532-cb15-d1f6a2af029a.htm
---
# Autodesk.Revit.DB.Document.PlanTopology Property

**中文**: 文档、文件

Get the PlanTopology of a given level in a given phase.

## Syntax (C#)
```csharp
public PlanTopology this[
	Level level,
	Phase phase
] { get; }
```

## Parameters
- **level** (`Autodesk.Revit.DB.Level`) - The level of the Plan Topology.
- **phase** (`Autodesk.Revit.DB.Phase`) - The phase of the Plan Topology.

## Remarks
Accessing plan topology requires that document is modifiable as it will actually trigger calculating plan topology if they have not been calculated yet. 
The time necessary for the calculations may be significant and should be considered.

