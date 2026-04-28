---
kind: method
id: M:Autodesk.Revit.DB.UpdaterRegistry.UnregisterUpdater(Autodesk.Revit.DB.UpdaterId)
source: html/6866986e-c8c2-f4c5-6c8c-4c9446e5b409.htm
---
# Autodesk.Revit.DB.UpdaterRegistry.UnregisterUpdater Method

Removes the updater associated with the input id from the UpdaterRegistry.
 Also removes all triggers associated with the Updater.

## Syntax (C#)
```csharp
public static void UnregisterUpdater(
	UpdaterId id
)
```

## Parameters
- **id** (`Autodesk.Revit.DB.UpdaterId`) - Id of updater to be removed

## Remarks
This methods works regardless of how the updater was registered.
 Whether the updater was registered application-wide or for a document
 (or a set of document), it will be removed from the registry and
 any connections with documents will also be lost.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Updater with this Id is not currently registered in Revit.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The updater's owner's AddIn does not match the currently active AddIn,
 i.e. IUpdater.GetUpdaterId().GetAddInId() differs from the addInId field
 in the manifest file of the currently executing external application.
 -or-
 Attempting to unregister an updater that is currently being executed.

