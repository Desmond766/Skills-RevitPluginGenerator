---
kind: property
id: P:Autodesk.Revit.DB.Document.Phases
zh: 文档、文件
source: html/362b427f-bf0d-6509-e541-9d5cc48e1837.htm
---
# Autodesk.Revit.DB.Document.Phases Property

**中文**: 文档、文件

Retrieves all of the phases in the document.

## Syntax (C#)
```csharp
public PhaseArray Phases { get; }
```

## Remarks
The phases are returned in order from earliest phase to latest phase. When Revit is running with UI activated, the default created phase for newly created elements is inherited from the phase of the currently active view. When Revit is running without its UI, such as when Revit runs on Autodesk Forge Design Automation API for Revit, 
the default phase for newly created elements is the latest phase in the document.

