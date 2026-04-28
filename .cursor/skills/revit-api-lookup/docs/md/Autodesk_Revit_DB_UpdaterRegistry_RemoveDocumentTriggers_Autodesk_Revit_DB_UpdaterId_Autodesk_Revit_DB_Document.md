---
kind: method
id: M:Autodesk.Revit.DB.UpdaterRegistry.RemoveDocumentTriggers(Autodesk.Revit.DB.UpdaterId,Autodesk.Revit.DB.Document)
source: html/453dd07f-bf65-803e-79d5-2ffa4316cf72.htm
---
# Autodesk.Revit.DB.UpdaterRegistry.RemoveDocumentTriggers Method

Removes all triggers associated with specified document and Updater
 Does not unregister updater.

## Syntax (C#)
```csharp
public static void RemoveDocumentTriggers(
	UpdaterId id,
	Document document
)
```

## Parameters
- **id** (`Autodesk.Revit.DB.UpdaterId`) - Id of specified updater
- **document** (`Autodesk.Revit.DB.Document`) - Document for which to remove triggers

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The updater's owner's AddIn does not match the currently active AddIn.
 -or-
 RemoveDocumentTriggers called while executing an updater.

