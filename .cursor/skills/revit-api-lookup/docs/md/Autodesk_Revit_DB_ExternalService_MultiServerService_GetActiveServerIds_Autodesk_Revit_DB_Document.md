---
kind: method
id: M:Autodesk.Revit.DB.ExternalService.MultiServerService.GetActiveServerIds(Autodesk.Revit.DB.Document)
source: html/dcfcdc0f-8926-b6b5-8337-5b71bd6a8719.htm
---
# Autodesk.Revit.DB.ExternalService.MultiServerService.GetActiveServerIds Method

Returns Ids of the servers currently applicable to the given document for the service.

## Syntax (C#)
```csharp
public IList<Guid> GetActiveServerIds(
	Document document
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The associated document.

## Returns
A set of GUIDs of the document-applicable active servers; the list may be empty.

## Remarks
The Ids would be of all the servers explicitly assigned to the specified document.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

