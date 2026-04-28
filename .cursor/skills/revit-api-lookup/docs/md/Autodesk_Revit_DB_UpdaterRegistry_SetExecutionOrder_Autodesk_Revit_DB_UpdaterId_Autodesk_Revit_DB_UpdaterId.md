---
kind: method
id: M:Autodesk.Revit.DB.UpdaterRegistry.SetExecutionOrder(Autodesk.Revit.DB.UpdaterId,Autodesk.Revit.DB.UpdaterId)
source: html/87d62116-cdb4-efc4-e2e2-e4f5b41b3441.htm
---
# Autodesk.Revit.DB.UpdaterRegistry.SetExecutionOrder Method

Forces execution order between two updaters
 Execution order: first before second

## Syntax (C#)
```csharp
public static void SetExecutionOrder(
	UpdaterId first,
	UpdaterId second
)
```

## Parameters
- **first** (`Autodesk.Revit.DB.UpdaterId`) - Id of first Updater
- **second** (`Autodesk.Revit.DB.UpdaterId`) - Id of second Updater

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - One or both inputs are not valid UpdaterIds
 -or-
 One or both of the Updaters are not registered
 -or-
 first and second are the same id
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentsInconsistentException** - The updaters do not report the same ChangePriority

