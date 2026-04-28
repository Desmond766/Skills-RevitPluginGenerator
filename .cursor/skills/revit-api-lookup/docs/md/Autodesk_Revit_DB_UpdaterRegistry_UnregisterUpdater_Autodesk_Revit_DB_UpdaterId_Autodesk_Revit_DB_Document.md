---
kind: method
id: M:Autodesk.Revit.DB.UpdaterRegistry.UnregisterUpdater(Autodesk.Revit.DB.UpdaterId,Autodesk.Revit.DB.Document)
source: html/5e544431-fb91-eb37-2e36-dccab0955ca8.htm
---
# Autodesk.Revit.DB.UpdaterRegistry.UnregisterUpdater Method

Unregisters an updater for the given document.

## Syntax (C#)
```csharp
public static void UnregisterUpdater(
	UpdaterId id,
	Document document
)
```

## Parameters
- **id** (`Autodesk.Revit.DB.UpdaterId`) - Id of updater to be unregistered.
- **document** (`Autodesk.Revit.DB.Document`) - Document for which this updater is to be unregistered.

## Remarks
Unregistering an updater from a document is only permitted if
 the updater was explicitly registered for that document.
If the updater was registered in other documents too,
 the remaining documents will still have the updater assigned.
However, if after unregistering from the document the updater is found
 not registered in any other (currently open) documents, the updater
 will be completely removed from the registry including its triggers.
 Should the updater be registered again later, the triggers need
 to be re-applied.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Updater with this Id is not currently registered in the document.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The updater's owner's AddIn does not match the currently active AddIn,
 i.e. IUpdater.GetUpdaterId().GetAddInId() differs from the addInId field
 in the manifest file of the currently executing external application.
 -or-
 Attempting to unregister an updater that is currently being executed.

