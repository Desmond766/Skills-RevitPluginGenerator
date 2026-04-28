---
kind: method
id: M:Autodesk.Revit.DB.MEPSystem.DivideSystem(Autodesk.Revit.DB.Document)
zh: 系统
source: html/1bb1e7d5-a9f6-0c2d-e413-064bd4aa2c02.htm
---
# Autodesk.Revit.DB.MEPSystem.DivideSystem Method

**中文**: 系统

Divide the phyisical networks in the system and create a new system for each network.

## Syntax (C#)
```csharp
public ICollection<ElementId> DivideSystem(
	Document ADoc
)
```

## Parameters
- **ADoc** (`Autodesk.Revit.DB.Document`) - The document.

## Returns
The id of new created systems.

## Remarks
This function only works for Hvac and Piping system.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The system is not dividable.

