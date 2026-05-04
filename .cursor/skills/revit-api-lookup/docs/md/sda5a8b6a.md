---
kind: method
id: M:Autodesk.Revit.DB.UpdaterRegistry.RemoveAllTriggers(Autodesk.Revit.DB.UpdaterId)
source: html/f8ae8eab-eeeb-2ba2-449e-6a6f46f88d2e.htm
---
# Autodesk.Revit.DB.UpdaterRegistry.RemoveAllTriggers Method

Removes all triggers associated with Updater with specified UpdaterId.
 Does not unregister updater.

## Syntax (C#)
```csharp
public static void RemoveAllTriggers(
	UpdaterId id
)
```

## Parameters
- **id** (`Autodesk.Revit.DB.UpdaterId`) - Id of specified updater

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The updater's owner's AddIn does not match the currently active AddIn.
 -or-
 RemoveAllTriggers called while executing an updater.

