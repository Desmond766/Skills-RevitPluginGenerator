---
kind: method
id: M:Autodesk.Revit.UI.IExternalCommandAvailability.IsCommandAvailable(Autodesk.Revit.UI.UIApplication,Autodesk.Revit.DB.CategorySet)
source: html/2c99572a-b16e-541a-3157-69263b499d06.htm
---
# Autodesk.Revit.UI.IExternalCommandAvailability.IsCommandAvailable Method

Implement this method to provide control over whether your external command is enabled or disabled.

## Syntax (C#)
```csharp
bool IsCommandAvailable(
	UIApplication applicationData,
	CategorySet selectedCategories
)
```

## Parameters
- **applicationData** (`Autodesk.Revit.UI.UIApplication`) - An ApplicationServices.Application object which contains reference to Application
needed by external command.
- **selectedCategories** (`Autodesk.Revit.DB.CategorySet`) - An list of categories of the elements which have been selected in Revit in the active document, 
or an empty set if no elements are selected or there is no active document.

## Returns
Indicates whether Revit should enable or disable the corresponding external command.

## Remarks
This callback will be called by Revit's user interface any time there is a contextual change. Therefore, the callback
must be fast and is not permitted to modify the active document and be blocking in any way.

