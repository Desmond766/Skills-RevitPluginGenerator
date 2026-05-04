---
kind: method
id: M:Autodesk.Revit.DB.ExternalService.IMultiServerService.CanExecute(Autodesk.Revit.DB.ExternalService.IExternalServer,Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ExternalService.IExternalData)
source: html/53edc57b-dea4-09a4-1c80-457bb60a4b02.htm
---
# Autodesk.Revit.DB.ExternalService.IMultiServerService.CanExecute Method

Implement this to test whether a particular server should be executed.

## Syntax (C#)
```csharp
bool CanExecute(
	IExternalServer server,
	Document document,
	IExternalData data
)
```

## Parameters
- **server** (`Autodesk.Revit.DB.ExternalService.IExternalServer`) - An instance of a server that is to be tested.
- **document** (`Autodesk.Revit.DB.Document`) - The associated document. It may be NULL if not applicable.
- **data** (`Autodesk.Revit.DB.ExternalService.IExternalData`) - The associated service data. It is the same data the Execute method would receive.

