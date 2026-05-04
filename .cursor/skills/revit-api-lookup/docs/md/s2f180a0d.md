---
kind: method
id: M:Autodesk.Revit.DB.UpdaterRegistry.AddTrigger(Autodesk.Revit.DB.UpdaterId,Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementFilter,Autodesk.Revit.DB.ChangeType)
source: html/8b898464-dad4-36c6-7f06-9a5ca372d2fa.htm
---
# Autodesk.Revit.DB.UpdaterRegistry.AddTrigger Method

Adds trigger with the specified element filter and ChangeType for the specified document

## Syntax (C#)
```csharp
public static void AddTrigger(
	UpdaterId id,
	Document document,
	ElementFilter filter,
	ChangeType change
)
```

## Parameters
- **id** (`Autodesk.Revit.DB.UpdaterId`) - Id of updater that trigger should be added to
- **document** (`Autodesk.Revit.DB.Document`) - Document that elements in 'elements' are contained in
- **filter** (`Autodesk.Revit.DB.ElementFilter`) - Element filter that defines elements that affect this trigger
- **change** (`Autodesk.Revit.DB.ChangeType`) - ChangeType associated with this trigger

## Remarks
This method only works with CategoryFilter and ParameterFilter.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The updater's owner's AddIn does not match the currently active AddIn.
 -or-
 The id does not correspond to any registered Updaters
 -or-
 AddTrigger called while executing an updater.

