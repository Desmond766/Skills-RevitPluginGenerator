---
kind: method
id: M:Autodesk.Revit.DB.LabelUtils.GetLabelFor(Autodesk.Revit.DB.Plumbing.PipeFlowState,Autodesk.Revit.DB.Document)
source: html/0fcc9faa-4526-622c-924e-5dad5c61c228.htm
---
# Autodesk.Revit.DB.LabelUtils.GetLabelFor Method

Gets the user-visible name for a PipeFlowState.

## Syntax (C#)
```csharp
public static string GetLabelFor(
	PipeFlowState pipeFlowState,
	Document doc
)
```

## Parameters
- **pipeFlowState** (`Autodesk.Revit.DB.Plumbing.PipeFlowState`) - The PipeFlowState to get the user-visible name.
- **doc** (`Autodesk.Revit.DB.Document`) - The document from which to get the PipeFlowState.

## Remarks
The name is obtained in the current Revit language.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when information for the input PipeFlowState cannot be found.

