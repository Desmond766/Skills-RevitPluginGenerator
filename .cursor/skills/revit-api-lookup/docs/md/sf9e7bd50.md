---
kind: method
id: M:Autodesk.Revit.DB.Structure.Truss.AttachChord(Autodesk.Revit.DB.Element,Autodesk.Revit.DB.Structure.TrussChordLocation,System.Boolean)
zh: 桁架
source: html/a0fc36fe-2c63-1a2c-0643-627b8560f09c.htm
---
# Autodesk.Revit.DB.Structure.Truss.AttachChord Method

**中文**: 桁架

Attach a truss's specific chord to a specified element, the element should be a roof or floor.

## Syntax (C#)
```csharp
public void AttachChord(
	Element attachToElement,
	TrussChordLocation location,
	bool forceRemoveSketch
)
```

## Parameters
- **attachToElement** (`Autodesk.Revit.DB.Element`) - The element to which the truss's chord will attach. The element should be a roof or floor.
- **location** (`Autodesk.Revit.DB.Structure.TrussChordLocation`) - The chord need to be attached.
- **forceRemoveSketch** (`System.Boolean`) - Whether to detach the original sketch if there is one.

