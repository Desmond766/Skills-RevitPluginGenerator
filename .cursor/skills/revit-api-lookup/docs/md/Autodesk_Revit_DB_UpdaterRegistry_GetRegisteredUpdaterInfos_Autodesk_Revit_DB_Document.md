---
kind: method
id: M:Autodesk.Revit.DB.UpdaterRegistry.GetRegisteredUpdaterInfos(Autodesk.Revit.DB.Document)
source: html/cfbf287a-a972-238e-def6-9c8cc6640db9.htm
---
# Autodesk.Revit.DB.UpdaterRegistry.GetRegisteredUpdaterInfos Method

Returns information about all updaters applicable to the given document.

## Syntax (C#)
```csharp
public static IList<UpdaterInfo> GetRegisteredUpdaterInfos(
	Document document
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document to which sought updaters are applicable to.

## Returns
List of UpdaterInfo structures

## Remarks
The list of data includes information about all updaters explicitly registered
 for the document as well as information about all application-wide registered
 updaters (which are applicable to all documents).

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

