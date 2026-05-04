---
kind: method
id: M:Autodesk.Revit.DB.UpdaterRegistry.RegisterUpdater(Autodesk.Revit.DB.IUpdater,Autodesk.Revit.DB.Document)
source: html/45900175-06d0-294f-4f4e-c11098e4adab.htm
---
# Autodesk.Revit.DB.UpdaterRegistry.RegisterUpdater Method

Registers the updater for a specified document, which means
 the updater can only be triggered by changes made in that document.

## Syntax (C#)
```csharp
public static void RegisterUpdater(
	IUpdater updater,
	Document document
)
```

## Parameters
- **updater** (`Autodesk.Revit.DB.IUpdater`) - Updater to be registered
- **document** (`Autodesk.Revit.DB.Document`) - Document for which this updater is to be registered

## Remarks
An updater may be registered in more than one document, but an updater
 may not be registered for a document and also for the entire application at
 the same time. If an updater has already been registered application-wide,
 an attempt to register it for a document will cause an exception.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Updater with the the same Id has already been registered on the application level.
 -or-
 Updater with the the same Id has already been registered either in the given document or on the application level.
 -or-
 Updater's Id is not valid.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Method is not allowed during execution of a dynamic update.
 -or-
 The updater's owner's AddIn does not match the currently active AddIn,
 i.e. IUpdater.GetUpdaterId().GetAddInId() differs from the addInId field
 in the manifest file of the currently executing external application.

