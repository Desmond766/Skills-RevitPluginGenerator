---
kind: property
id: P:Autodesk.Revit.DB.Document.PlanTopologies(Autodesk.Revit.DB.Phase)
zh: 文档、文件
source: html/6cead23c-595a-8f54-8692-aa9daad9fb8d.htm
---
# Autodesk.Revit.DB.Document.PlanTopologies Property

**中文**: 文档、文件

Gets the PlanTopologies of the current project in a given phase.

## Syntax (C#)
```csharp
public PlanTopologySet this[
	Phase phase
] { get; }
```

## Parameters
- **phase** (`Autodesk.Revit.DB.Phase`) - The phase of the Plan Topology.

## Remarks
Accessing plan topologies requires that document is modifiable as it will actually trigger calculating plan topologies if they have not been calculated yet. 
The time necessary for the calculations may be significant and should be considered.

