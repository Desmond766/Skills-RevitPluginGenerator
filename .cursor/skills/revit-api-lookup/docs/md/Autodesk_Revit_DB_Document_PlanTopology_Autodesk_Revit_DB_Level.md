---
kind: property
id: P:Autodesk.Revit.DB.Document.PlanTopology(Autodesk.Revit.DB.Level)
zh: 文档、文件
source: html/fb7a12ec-d4d7-b3a5-3613-5ee23d45c52f.htm
---
# Autodesk.Revit.DB.Document.PlanTopology Property

**中文**: 文档、文件

Get the PlanTopology of a given level in the last phase.

## Syntax (C#)
```csharp
public PlanTopology this[
	Level level
] { get; }
```

## Parameters
- **level** (`Autodesk.Revit.DB.Level`) - The level of the Plan Topology.

## Remarks
Accessing plan topology requires that document is modifiable as it will actually trigger calculating plan topology if they have not been calculated yet. 
The time necessary for the calculations may be significant and should be considered.

