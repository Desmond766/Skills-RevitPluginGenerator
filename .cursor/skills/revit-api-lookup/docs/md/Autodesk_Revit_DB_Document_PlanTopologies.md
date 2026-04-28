---
kind: property
id: P:Autodesk.Revit.DB.Document.PlanTopologies
zh: 文档、文件
source: html/b782b091-bcd9-6759-9e39-4cd7a5bf3143.htm
---
# Autodesk.Revit.DB.Document.PlanTopologies Property

**中文**: 文档、文件

Get the PlanTopologies of the current project in the last phase.

## Syntax (C#)
```csharp
public PlanTopologySet PlanTopologies { get; }
```

## Remarks
Accessing plan topologies requires that document is modifiable as it will actually trigger calculating plan topologies if they have not been calculated yet. 
The time necessary for the calculations may be significant and should be considered.

