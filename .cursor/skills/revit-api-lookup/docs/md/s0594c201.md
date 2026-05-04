---
kind: method
id: M:Autodesk.Revit.DB.BrowserOrganization.GetCurrentBrowserOrganizationForViews(Autodesk.Revit.DB.Document)
source: html/08b2637d-816b-5cca-541d-8e3168bef3e7.htm
---
# Autodesk.Revit.DB.BrowserOrganization.GetCurrentBrowserOrganizationForViews Method

Gets the BrowserOrganization that applies to the Views section of the project browser.

## Syntax (C#)
```csharp
public static BrowserOrganization GetCurrentBrowserOrganizationForViews(
	Document document
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - Revit document from which to get the organization data.

## Returns
The BrowserOrganization for views, or null if no view sections exist

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

