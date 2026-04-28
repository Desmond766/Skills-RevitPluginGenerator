---
kind: method
id: M:Autodesk.Revit.DB.UpdaterRegistry.RegisterUpdater(Autodesk.Revit.DB.IUpdater,System.Boolean)
source: html/edffd44c-2511-c9ee-f330-5cd77414d0e9.htm
---
# Autodesk.Revit.DB.UpdaterRegistry.RegisterUpdater Method

Registers an updater application-wide, which means
 the updater may get triggered in any open document.

## Syntax (C#)
```csharp
public static void RegisterUpdater(
	IUpdater updater,
	bool isOptional
)
```

## Parameters
- **updater** (`Autodesk.Revit.DB.IUpdater`) - Updater to be registered
- **isOptional** (`System.Boolean`) - This argument controls whether the updater should be required next time a document
 is open in which the updater had been previously used. If a non-optional updater is
 not found (i.e. currently not registered), the end user will be presented with a warning
 and choices to resolve the situation.

## Remarks
By registering an updater application-wide, any previous registration explicitly made
 for particular documents will be voided. That means the updater will no longer be connected
 with just those documents, and the methodIsUpdaterRegistered(id,document) will also
 return False. Consequently, any attempt to either register or unregister this updater
 to (or from, respectively) a document will cause an exception to be thrown.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Updater with the the same Id has already been registered on the application level.
 -or-
 Updater's Id is not valid.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Method is not allowed during execution of a dynamic update.
 -or-
 The updater's owner's AddIn does not match the currently active AddIn,
 i.e. IUpdater.GetUpdaterId().GetAddInId() differs from the addInId field
 in the manifest file of the currently executing external application.

