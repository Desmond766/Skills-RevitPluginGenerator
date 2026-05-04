---
kind: method
id: M:Autodesk.Revit.DB.TableView.GetAvailableParameters(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
source: html/a97f0bbc-537f-5930-5430-144885dfd39a.htm
---
# Autodesk.Revit.DB.TableView.GetAvailableParameters Method

Gets a list of valid parameters for the specified category that can be used in the table view.

## Syntax (C#)
```csharp
public static IList<ElementId> GetAvailableParameters(
	Document cda,
	ElementId categoryId
)
```

## Parameters
- **cda** (`Autodesk.Revit.DB.Document`) - The document.
- **categoryId** (`Autodesk.Revit.DB.ElementId`) - The specified element category id.

## Returns
The IDs of all valid parameters.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

