---
kind: method
id: M:Autodesk.Revit.DB.Plumbing.PipingSystem.DeleteHydraulicSeparation(Autodesk.Revit.DB.Document,System.Collections.Generic.ISet{Autodesk.Revit.DB.ElementId})
source: html/5524b379-b150-2181-3a33-d985ff2aa81f.htm
---
# Autodesk.Revit.DB.Plumbing.PipingSystem.DeleteHydraulicSeparation Method

Deletes hydraulically separated systems and merges the system components into the connected system.

## Syntax (C#)
```csharp
public static void DeleteHydraulicSeparation(
	Document document,
	ISet<ElementId> pipeElementIds
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document where the system is deleted.
- **pipeElementIds** (`System.Collections.Generic.ISet < ElementId >`) - The boundary pipe that separates the system. Multiple pipes are allowed to delete more than one separated systems.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - One or more elements is not a pipe.
 -or-
 One or more elements is not a valid loop boundary.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

