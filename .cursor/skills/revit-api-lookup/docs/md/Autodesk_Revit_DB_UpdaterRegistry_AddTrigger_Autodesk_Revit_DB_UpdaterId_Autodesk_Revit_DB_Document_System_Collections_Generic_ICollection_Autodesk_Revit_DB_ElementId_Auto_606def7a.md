---
kind: method
id: M:Autodesk.Revit.DB.UpdaterRegistry.AddTrigger(Autodesk.Revit.DB.UpdaterId,Autodesk.Revit.DB.Document,System.Collections.Generic.ICollection{Autodesk.Revit.DB.ElementId},Autodesk.Revit.DB.ChangeType)
source: html/2c6c9876-8f97-24be-9799-2adab7c75363.htm
---
# Autodesk.Revit.DB.UpdaterRegistry.AddTrigger Method

Adds a trigger to an updater with specified set of elements and ChangeType

## Syntax (C#)
```csharp
public static void AddTrigger(
	UpdaterId id,
	Document document,
	ICollection<ElementId> elements,
	ChangeType change
)
```

## Parameters
- **id** (`Autodesk.Revit.DB.UpdaterId`) - Id of updater that trigger should be added to
- **document** (`Autodesk.Revit.DB.Document`) - Document that elements in 'elements' are contained in
- **elements** (`System.Collections.Generic.ICollection < ElementId >`) - Set of elements which define this trigger
- **change** (`Autodesk.Revit.DB.ChangeType`) - ChangeType associated with this trigger

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - updater's owner AddIn does not match the currently active AddIn
 -or-
 id does not correspond to any registered Updaters
 -or-
 AddTrigger called while executing an updater.

