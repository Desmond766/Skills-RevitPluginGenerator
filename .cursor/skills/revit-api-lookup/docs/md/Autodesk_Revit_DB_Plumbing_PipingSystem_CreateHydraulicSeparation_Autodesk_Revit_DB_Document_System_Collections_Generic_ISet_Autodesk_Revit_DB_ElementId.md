---
kind: method
id: M:Autodesk.Revit.DB.Plumbing.PipingSystem.CreateHydraulicSeparation(Autodesk.Revit.DB.Document,System.Collections.Generic.ISet{Autodesk.Revit.DB.ElementId})
source: html/26d64a31-4fb6-cc54-af42-fc2bc1db479d.htm
---
# Autodesk.Revit.DB.Plumbing.PipingSystem.CreateHydraulicSeparation Method

Creates new system which is hydraulically separated from the existing system.

## Syntax (C#)
```csharp
public static ISet<ElementId> CreateHydraulicSeparation(
	Document document,
	ISet<ElementId> pipeElementIds
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document where the new system is created.
- **pipeElementIds** (`System.Collections.Generic.ISet < ElementId >`) - The boundary pipe that defines a new system. Multiple pipes are allowed to create more than one separated systems.

## Returns
The newly created piping system elements.

## Remarks
Hydraulically separated systems allow independent flow and pressure analysis for each hydraulic loop.
 For example, each hydraulic loop has its own cirtical path. The calculated pressure drop on the primary
 pump is consisted of all pressure drop on the primary critical path. Any pressure drop on the secondary
 loop would only contribute to the calculated pressure drop of the secondary pump.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - One or more elements is not a pipe.
 -or-
 One or more elements is already the loop boundary.
 -or-
 One or more elements can not be used as loop boundary. Check if the element connects to any junction.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

